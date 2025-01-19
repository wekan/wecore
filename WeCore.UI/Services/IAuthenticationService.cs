using WeCore.UI.Models;

namespace WeCore.UI.Services
{
    public interface IAuthenticationService
    {
        Task<bool> Login(LoginModel loginModel);
        Task<bool> Register(RegisterModel registerModel);
        Task Logout();
    }
}
