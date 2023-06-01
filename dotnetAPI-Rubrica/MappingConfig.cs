﻿using AutoMapper;
using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Models.DTO;
using dotnetAPI_footballTeam.Models.DTO.PlayersDTO;
using dotnetAPI_footballTeam.Models.DTO.TeamsDTO;
using dotnetAPI_Rubrica.Models;

namespace dotnetAPI_footballTeam
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ApplicationUser,UserDTO>().ForMember(dest => dest.TeamName, from => from.MapFrom(src => src.Team.Name)).ReverseMap();
            CreateMap<Player,PlayerWithTeamNameDTO>().ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name)).ReverseMap();
            CreateMap<Player, PlayerCreateDTO>().ReverseMap();
            CreateMap<Player, PlayerWithoutTeamDTO>().ReverseMap();
            CreateMap<Team,TeamWithUserDTO>()
                .ForMember(dest => dest.Username, from => from.MapFrom(src => src.ApplicationUser.UserName))
                .ForMember(dest => dest.UserEmail, from => from.MapFrom(src => src.ApplicationUser.Email))
                .ReverseMap();
            CreateMap<Team, TeamCreateDTO>().ReverseMap();
        }
    }
}
