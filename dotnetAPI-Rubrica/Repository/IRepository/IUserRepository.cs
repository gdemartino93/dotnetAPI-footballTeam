﻿using dotnetAPI_footballTeam.Models.DTO;

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
        
    }
}
