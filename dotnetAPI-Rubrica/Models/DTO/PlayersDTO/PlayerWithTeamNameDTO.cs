using dotnetAPI_Rubrica.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetAPI_footballTeam.Models.DTO.PlayersDTO
{
    public class PlayerWithTeamNameDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? ContractExpiration { get; set; }
        public string Role { get; set; }
        public decimal Value { get; set; }
        //public Team? Team { get; set; }
        public string? TeamName { get; set; } 
    }
}
