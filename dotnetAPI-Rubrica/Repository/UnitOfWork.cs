using dotnetAPI_footballTeam.Data;
using dotnetAPI_footballTeam.Repository.IRepository;

namespace dotnetAPI_footballTeam.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IPlayerRepository PlayerRepository { get ; private set; }
        public ITeamRepository TeamRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            PlayerRepository = new PlayerRepository(_db);
            TeamRepository = new TeamRepository(_db);
        }
    }
}
