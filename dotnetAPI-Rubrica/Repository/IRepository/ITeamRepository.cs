using dotnetAPI_footballTeam.Models.DTO.TeamsDTO;
using dotnetAPI_Rubrica.Models;

namespace dotnetAPI_footballTeam.Repository.IRepository
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task CreateTeamAsync(TeamCreateDTO teamDto);
    }
}
