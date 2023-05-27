using dotnetAPI_footballTeam.Data;
using dotnetAPI_footballTeam.Repository.IRepository;
using dotnetAPI_Rubrica.Models;

namespace dotnetAPI_footballTeam.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
