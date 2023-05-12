using AutoMapper;
using dotnetAPI_Rubrica.Data;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Models.DTO;
using dotnetAPI_Rubrica.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotnetAPI_Rubrica.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private string secretKey;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext dbContext,
                              IConfiguration config,
                              RoleManager<IdentityRole> roleManager,
                              UserManager<ApplicationUser> userManager,
                              IMapper mapper)
        {
            _dbContext = dbContext;
            secretKey = config.GetValue("ApiSetting", "secreyKey");
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public bool IsUniqueUser(string value)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName == value);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.Username.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null,
                };
            }
            var token = GenerateJwtToken(user, secretKey);
            var roles = await _userManager.GetRolesAsync(user);
            var loginResponseDTO = new LoginResponseDTO()
            {
                Token = token,
                User = _mapper.Map<UserDTO>(user),
            };
            return loginResponseDTO;
        }

        public async Task<UserDTO> Register(RegisterRequestDTO registerRequestDTO)
        {
            ApplicationUser newUser = new()
            {
                UserName = registerRequestDTO.Username,
                Name = registerRequestDTO.Name,
                Lastname = registerRequestDTO.Lastname,
                Email = registerRequestDTO.Email
            };
            try
            {
                var createdNewUser = await _userManager.CreateAsync(newUser, registerRequestDTO.Password);
                if (createdNewUser.Succeeded)
                {
                    //creiamo i ruoli se non esistono(da spostare in db)
                    if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
                        await _roleManager.CreateAsync(new IdentityRole { Name = "user" });
                    }
                    //assegnaimo il ruolo all'utente appena creato
                    await _userManager.AddToRoleAsync(newUser, "user");
                    //creiamo l'oggetto da ritoranre
                    var userToReturn = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName == registerRequestDTO.Username);

                    return _mapper.Map<UserDTO>(userToReturn);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new UserDTO();
        }

        //generiamo il token jwt
        private string GenerateJwtToken(ApplicationUser user, string secretKey)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7), //token expires
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
