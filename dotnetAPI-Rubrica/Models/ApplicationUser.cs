using dotnetAPI_Rubrica.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetAPI_footballTeam.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public Team? Team { get; set; }


    }
}
