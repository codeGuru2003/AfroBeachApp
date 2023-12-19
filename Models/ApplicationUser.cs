using Microsoft.AspNetCore.Identity;

namespace AfroBeachApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
    }
}
