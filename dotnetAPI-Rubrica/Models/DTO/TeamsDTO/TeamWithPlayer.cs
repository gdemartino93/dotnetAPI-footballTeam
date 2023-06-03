namespace dotnetAPI_footballTeam.Models.DTO.TeamsDTO
{
    public class TeamWithPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }
        public string ApplicationUserId { get; set; }
        public int PId { get; set; }
        public string PName { get; set; }
        public string PLastname { get; set; }
        public DateTime PDateOfBirth { get; set; }
        public DateTime? PContractExpiration { get; set; }
        public string PRole { get; set; }
        public decimal PValue { get; set; }
    }
}
