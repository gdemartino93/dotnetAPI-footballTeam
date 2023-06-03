using AutoMapper;
using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using dotnetAPI_footballTeam.Models.DTO.TeamsDTO;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_footballTeam.Models.DTO;

namespace dotnetAPI_footballTeam.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private APIResponse _response;
        private IUserRepository _userRepository;

        public TeamsController(IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _response = new APIResponse();
            _userRepository = userRepository;

        }
        [HttpGet("GetTeamsWithUser")]
        public async Task<APIResponse> GetTeamsWithUser()
        {
            var teamList = await _unitOfWork.TeamRepository.GetAllAsync(includeProperties: "ApplicationUser");
            if (teamList.Count == 0)
            {
                _response.Result = "Non ci sono team";
                _response.IsSuccess = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return _response;
            }
            var teamListDto =  _mapper.Map<List<TeamWithUserDTO>>(teamList);
            _response.Result = teamListDto;
            _response.IsSuccess = true;
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return _response;
        }

        [HttpPost("CreateTeam")]
        public async Task<APIResponse> CreateTeam(TeamCreateDTO teamDto)
        {
            //var team = _mapper.Map<Team>(teamDto);
           await _unitOfWork.TeamRepository.CreateTeamAsync(teamDto);

           // await _userRepository.UpdateAsync(_mapper.Map<ApplicationUser>(user));

            _response.Result = "dio"; 
            _response.IsSuccess = true;
            return _response;
        }
        [HttpGet("GetTeamOfUser")]
        public async Task<APIResponse> GetTeamOfUser(string userId)
        {
            Team team = await _unitOfWork.TeamRepository.GetAsync(t => t.ApplicationUserId == userId,includeProperties: "Player");
            if (team is null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                _response.IsSuccess = true;
                return _response;
            }
            _response.Result = team;
            _response.IsSuccess = true;
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return _response;
        }


    }
}
