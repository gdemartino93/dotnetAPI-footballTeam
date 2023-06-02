using AutoMapper;
using dotnetAPI_footballTeam.Data;
using dotnetAPI_footballTeam.Models.DTO.TeamsDTO;
using dotnetAPI_footballTeam.Repository.IRepository;
using dotnetAPI_Rubrica.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetAPI_footballTeam.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public TeamRepository(ApplicationDbContext db,IMapper mapper) : base(db)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task CreateTeamAsync(TeamCreateDTO teamDto)
        {
            try
            {
                Team team = _mapper.Map<Team>(teamDto);
                 _db.Add(team);
                await _db.SaveChangesAsync();

                var user = _db.Users.Where(u => u.Id == teamDto.ApplicationUserId).FirstOrDefault();
                user.TeamId = team.Id;
                if (user.TeamId is null)
                {
                    throw new Exception("team id null");
                }
                
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }


    }
}
