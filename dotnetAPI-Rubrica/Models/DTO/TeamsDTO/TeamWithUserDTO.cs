using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetAPI_footballTeam.Models.DTO.TeamsDTO
{
    public class TeamWithUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }
        public string ApplicationUserId { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
    }
}
