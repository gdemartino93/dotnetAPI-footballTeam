using dotnetAPI_Rubrica.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetAPI_footballTeam.Models
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? ContractExpiration { get; set; }
        public string Role { get; set; }
        public decimal Value { get; set; }
        [ForeignKey("Team")]
        public string? TeamId { get; set; }
        [NotMapped]
        public Team? Team { get; set; }
    }
}
