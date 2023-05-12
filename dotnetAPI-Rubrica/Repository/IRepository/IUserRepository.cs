using dotnetAPI_Rubrica.Models.DTO;

namespace dotnetAPI_Rubrica.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string value);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegisterRequestDTO registerRequestDTO);
        
    }
}
