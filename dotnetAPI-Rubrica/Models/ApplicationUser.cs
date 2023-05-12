using Microsoft.AspNetCore.Identity;

namespace dotnetAPI_Rubrica.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
    }
}
