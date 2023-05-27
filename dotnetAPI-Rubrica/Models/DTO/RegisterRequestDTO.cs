namespace dotnetAPI_footballTeam.Models.DTO
{
    public class RegisterRequestDTO
    {
        public string Username { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
