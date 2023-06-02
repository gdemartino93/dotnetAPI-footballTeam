using dotnetAPI_Rubrica.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetAPI_footballTeam.Models.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public int? TeamId { get; set; }
        public string? TeamName { get; set; }
        [ForeignKey("TeamId")]
        public Team? Team { get; set; }
    }
}
