using WeCore.UI.Models;

namespace WeCore.UI.Services
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(LoginModel loginModel);
        Task<bool> Login(LoginModel loginModel);
        Task LogoutAsync();
    }
}
