using dotnetAPI_footballTeam.Models;
using System.ComponentModel.DataAnnotations;

namespace dotnetAPI_Rubrica.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }
    }
}
