using dotnetAPI_footballTeam.Data;
using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Repository.IRepository;

namespace dotnetAPI_footballTeam.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
