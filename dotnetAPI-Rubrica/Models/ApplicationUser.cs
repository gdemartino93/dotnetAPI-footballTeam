using Microsoft.AspNetCore.Identity;

namespace dotnetAPI_footballTeam.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
    }
}
