using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Models.DTO;
using dotnetAPI_Rubrica.Models;
using System.Linq.Expressions;

namespace dotnetAPI_footballTeam.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        bool IsUniqueEmail(string email);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegisterRequestDTO registerRequestDTO);
        bool IsValidEmail(string email);
        Task<UserDTO> GetUserByUsername(string username);
        Task<UserDTO> GetUserById(string id);

        Task<UserDTO> EditNameAndLastnameOfUser(UserDTO user);
        Task<bool> HasTeam(string teamName);
        List<UserDTO> GetAllUsers();
        Task<IQueryable<UserDTO>> GetAllAsync(Expression<Func<UserDTO, bool>> filter = null, string includeProperties = "", int pageSize = 0, int currentPage = 0);


    }
}
