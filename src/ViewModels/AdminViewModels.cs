namespace WeCore.Api.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public IList<string> Roles { get; set; }
    }

    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }

    public class ResetPasswordViewModel
    {
        public string NewPassword { get; set; }
    }
}
