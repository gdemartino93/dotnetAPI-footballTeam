using AutoMapper;
using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Models.DTO.PlayersDTO;
using dotnetAPI_footballTeam.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net;

namespace dotnetAPI_footballTeam.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        private APIResponse _response;
        private IMapper _mapper;
        public PlayersController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _response = new APIResponse();
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<APIResponse> GetAllPlayersWithTeamName()
        {
            var playersList = await _unitOfWork.PlayerRepository.GetAllAsync(includeProperties:"Team");
            var playersListDTO = _mapper.Map<List<PlayerWithTeamNameDTO>>(playersList);

            if(playersList.Count == 0)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = "Nessun giocatore presente";
                return _response;
            }
            else
            {
                _response.Result = playersListDTO;
                return _response;
            }

        }
        [HttpPost("CreatePlayer")]
        public async Task<APIResponse> CreatePlayer(PlayerCreateDTO playerDTO)
        {
            try
            {
                Player newPlayer = _mapper.Map<Player>(playerDTO);
                if(playerDTO.Value <= 0 && (playerDTO.TeamId is not null || playerDTO.TeamId != 0))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessage.Add("Il giocatore con una squadra deve avere un valore maggiore di 0.");
                }
                await _unitOfWork.PlayerRepository.CreateAsync(newPlayer);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                return _response;
            }
            catch (Exception e)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
               foreach(var err in e.Message.Split('\n'))
                {
                    _response.ErrorMessage.Add(err);
                }
               return _response;
            }
            
        }
        [HttpDelete("DeletePlayer")]
        public async Task<APIResponse> DeletePlayer(int id)
        {
            var player = await _unitOfWork.PlayerRepository.GetAsync(p => p.Id == id);
            if(player is null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return _response;
            }
            await _unitOfWork.PlayerRepository.RemoveAsync(player);
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = "Giocatore eliminato";
            return _response;
        }
        [HttpGet("GetPlayerWithNoTeam")]
        public async Task<APIResponse> GetPlayerWithNoTeam()
        {
            List<Player> playersWithNoTeam = await _unitOfWork.PlayerRepository.GetAllAsync(p => p.TeamId == null);
            if(playersWithNoTeam is null)
            {
                _response.IsSuccess =false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return _response;
            }
            if(playersWithNoTeam.Count == 0)
            {
                _response.Result = "Non ci sono giocatori svincolati";
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return _response;
            }
            var playersWithNoTeamDTO = _mapper.Map<List<PlayerWithoutTeamDTO>>(playersWithNoTeam);
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = playersWithNoTeamDTO;
            return _response;
        }
        [HttpPut("ExtendContract")]
        public async Task<APIResponse> ExtendPlayerContract(int id,DateTime newExpiringDate)
        {
            var player  = await _unitOfWork.PlayerRepository.GetAsync(p => p.Id == id);
            if(player is null)
            {
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.Result = "Giocatore non trovato";
                return _response;
            }
            if(player.ContractExpiration <  DateTime.UtcNow)
            {
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Il contratto del giocatore è già scaduto");
                return _response;
            }
            if(newExpiringDate <= DateTime.UtcNow)
            {
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.UnprocessableEntity;
                _response.ErrorMessage.Add($"La nuova data non può essere precedente a {DateTime.Now}");
                return _response;

            }
            player.ContractExpiration = newExpiringDate;
            await _unitOfWork.PlayerRepository.UpdateAsync(player);
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return _response;



        }
        [HttpPut("ChangeTeam")]
        public async Task<APIResponse> ChangeTeam(int id, int idNewTeam)
        {
            var player = await _unitOfWork.PlayerRepository.GetAsync(p => p.Id == id);
            if(player is null)
            {
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.ErrorMessage.Add("Nessun giocatore trovato");
                return _response;
            }
            var teamsAvaible = await _unitOfWork.TeamRepository.GetAllAsync();
            foreach(var team in teamsAvaible)
            {
                if( team.Id == idNewTeam)
                {
                    player.TeamId = idNewTeam;
                    await _unitOfWork.PlayerRepository.UpdateAsync(player);
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.OK;
                    return _response;
                }
            }
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.ErrorMessage.Add("Team non trovato");
            return _response;
        }
    }
}
