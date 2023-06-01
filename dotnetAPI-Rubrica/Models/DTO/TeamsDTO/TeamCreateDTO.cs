namespace dotnetAPI_footballTeam.Models.DTO.TeamsDTO
{
    public class TeamCreateDTO
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
