using AutoMapper;
using dotnetAPI_footballTeam.Data;
using dotnetAPI_footballTeam.Repository.IRepository;

namespace dotnetAPI_footballTeam.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        private IMapper _mapper;
        public IPlayerRepository PlayerRepository { get ; private set; }
        public ITeamRepository TeamRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            PlayerRepository = new PlayerRepository(_db);
            TeamRepository = new TeamRepository(_db,_mapper);
        }
    }
}
