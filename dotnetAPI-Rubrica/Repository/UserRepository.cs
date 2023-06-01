﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using dotnetAPI_footballTeam.Data;
using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Models.DTO;
using dotnetAPI_footballTeam.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnetAPI_footballTeam.Repository
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
            secretKey = config.GetValue<string>("ApiSettings:secretKey");
            Console.WriteLine(secretKey);
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public bool IsUniqueUser(string username)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName == username);
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
                Role = roles.FirstOrDefault()
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
            else
            {
                var error = createdNewUser.Errors.FirstOrDefault();
                if (error != null)
                {
                    throw new ArgumentException(error.Description);
                }
            }

            return null;
        }



        private string GenerateJwtToken(ApplicationUser user, string secretKey)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool IsUniqueEmail(string email)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Email == email);
            if( user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidEmail(string email)
        {
            // regex per validare l'email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public Task<UserDTO> GetUserByUsername(string username)
        {
            ApplicationUser user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName == username);
            user.Team =  _dbContext.Teams.Where(t => t.Id == user.TeamId).FirstOrDefault();
            if( user == null )
            {
                return Task.FromResult<UserDTO>(null);
            }
             UserDTO userDTO = _mapper.Map<UserDTO>(user);
             return Task.FromResult(userDTO);
        }
        public async Task<UserDTO> EditNameAndLastnameOfUser(UserDTO user)
        {
            try
            {
                var userApplication = _dbContext.ApplicationUsers.Where(u => u.UserName == user.Username).FirstOrDefault();
                ;
                if( userApplication == null )
                {
                    throw new Exception("User non trovato");
                }
                userApplication.Name = user.Name;
                userApplication.Lastname = user.Lastname;
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<UserDTO>(userApplication);
            }
            catch (Exception ex)
            {

                throw new Exception($"Eccezione:{ex.Message}");
            }
        }

        public async Task<bool> HasTeam(string username)
        {
            var user =  _dbContext.ApplicationUsers.Where(u => u.UserName == username).FirstOrDefault() ?? throw new Exception("Utente non trovato");

            if(user.TeamId is not null && user.TeamId != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<UserDTO> GetAllUsers()
        {
            var users = _dbContext.ApplicationUsers.ToList();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<IQueryable<UserDTO>> GetAllAsync(Expression<Func<UserDTO, bool>> filter = null, string includeProperties = "", int pageSize = 0, int currentPage = 0)
        {
            IQueryable<ApplicationUser> query = _dbContext.Users;


            if (!string.IsNullOrEmpty(includeProperties))
            {
                query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty.Trim()));
            }

            if (filter != null)
            {
                var userFilter = _mapper.Map<Expression<Func<ApplicationUser, bool>>>(filter);
                query = query.Where(userFilter);
            }

            IQueryable<UserDTO> result = query.ProjectTo<UserDTO>(_mapper.ConfigurationProvider);

            if (pageSize > 0 && currentPage > 0)
            {
                result = result.Skip((currentPage - 1) * pageSize).Take(pageSize);
            }

            return await Task.FromResult(result);
        }
        public Task<UserDTO> GetUserById(string id)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return Task.FromResult<UserDTO>(null);
            }
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return Task.FromResult(userDTO);
        }

    }
}
