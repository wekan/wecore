using Microsoft.JSInterop;
using System.Net.Http.Json;
using WeCore.UI.Models;

namespace WeCore.UI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private const string AUTH_TOKEN_KEY = "authToken";

        public AuthenticationService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        // Temporary implementation for testing
        public async Task<bool> Login(LoginModel loginModel)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> Register(RegisterModel registerModel)
        {
            return await Task.FromResult(true);
        }

        public async Task Logout()
        {
            await Task.CompletedTask;
        }

        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginModel);
                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", AUTH_TOKEN_KEY, token);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", AUTH_TOKEN_KEY);
            await _httpClient.PostAsync("api/auth/logout", null);
        }
    }
}
