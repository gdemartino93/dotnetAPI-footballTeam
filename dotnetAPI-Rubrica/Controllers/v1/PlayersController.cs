using AutoMapper;
using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Models.DTO.PlayersDTO;
using dotnetAPI_footballTeam.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<APIResponse> GetAllPlayersWithTeamNabe()
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
    }
}
