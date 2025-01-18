using Microsoft.Extensions.DependencyInjection;

namespace WeCore.Api.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWekanServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
