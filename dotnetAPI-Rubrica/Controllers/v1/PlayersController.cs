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
        public async Task<APIResponse> GetAllPlayers()
        {
            var playersList = await _unitOfWork.PlayerRepository.GetAllAsync(includeProperties:"Team");
            if(playersList.Count() == 0)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = "Nessun giocatore presente";
                return _response;
            }
            else
            {
                _response.Result = playersList;
                return _response;
            }

        }
    }
}
