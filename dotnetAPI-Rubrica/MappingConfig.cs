using AutoMapper;
using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Models.DTO;
using dotnetAPI_footballTeam.Models.DTO.PlayersDTO;

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
        }
    }
}
