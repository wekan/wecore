using Microsoft.AspNetCore.Identity;

namespace WeCore.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string DisplayName { get; set; }
        public required string Department { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
