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
            CreateMap<ApplicationUser,UserDTO>().ReverseMap();
            CreateMap<Player,PlayerDTO>().ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name)).ReverseMap();

        }
    }
}
