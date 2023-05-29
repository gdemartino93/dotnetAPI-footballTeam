namespace dotnetAPI_footballTeam.Models.DTO.PlayersDTO
{
    public class PlayerCreateDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? ContractExpiration { get; set; }
        public string Role { get; set; }
        public decimal Value { get; set; }
        public int? TeamId { get; set; }

    }
}
