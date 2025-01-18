using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WeCore.Data;
using WeCore.Services;
using WeCore.Authorization;
using WeCore.Middleware;

public class Startup
{
    // ...existing code...
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<KanbanContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.Configure<IISOptions>(options =>
        {
            options.AutomaticAuthentication = true;
            options.ForwardClientCertificate = false;
        });

        services.AddAuthentication(IISDefaults.AuthenticationScheme)
                .AddNegotiate();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdminRole", policy =>
                policy.RequireRole("Admin"));
        });

        // Register Kanban services
        services.AddScoped<IBoardService, BoardService>();
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IUserManagementService, UserManagementService>();
        services.AddScoped<IAuthorizationHandler, KanbanAuthorizationHandler>();

        // Add session support for user preferences
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        
        // Add custom middleware for user context
        app.UseMiddleware<UserContextMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "admin",
                pattern: "admin/{controller=Users}/{action=Index}/{id?}")
                .RequireAuthorization("RequireAdminRole");

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Board}/{action=Index}/{id?}");
        });
    }
}
