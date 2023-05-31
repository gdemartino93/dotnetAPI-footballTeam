using AutoMapper;
using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using dotnetAPI_footballTeam.Models.DTO.TeamsDTO;

namespace dotnetAPI_footballTeam.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private APIResponse _response;

        public TeamsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _response = new APIResponse();
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
    }
}
