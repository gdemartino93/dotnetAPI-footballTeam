using dotnetAPI_footballTeam.Data;
using dotnetAPI_footballTeam.Models;
using dotnetAPI_footballTeam.Models.DTO;
using dotnetAPI_footballTeam.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace dotnetAPI_footballTeam.Controllers
{
    [Route("api/UserAuth")]
    [ApiController]
    [ApiVersionNeutral]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private APIResponse _response;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new APIResponse();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginRes = await _userRepository.Login(loginRequestDTO);
            if (loginRes.User == null || string.IsNullOrEmpty(loginRes.Token))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Username o password non corretti");
                _response.Result = "Username o password non corretti";
                return BadRequest(_response);
            }
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            _response.Result = loginRes;
            _response.IsSuccess = true;

            return Ok(_response);
        }
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            //check if password matches
            if (registerRequestDTO.Password != registerRequestDTO.ConfirmPassword)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Le password devono essere uguali");
                return BadRequest(_response);
            }
            if (!_userRepository.IsValidEmail(registerRequestDTO.Email))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.UnprocessableEntity;
                _response.ErrorMessage.Add("Inserisci un email valida");
                return UnprocessableEntity(_response);
            }
            //check if username and email already exist
            bool usernameExist = _userRepository.IsUniqueUser(registerRequestDTO.Username);
            bool emailExist = _userRepository.IsUniqueEmail(registerRequestDTO.Email);
            //if already exist
            if (!usernameExist && !emailExist)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }

            try
            {
                var newUser = await _userRepository.Register(registerRequestDTO);
                if (newUser is not null)
                {
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.Created;
                    _response.Result = newUser;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.UnprocessableEntity;
                _response.ErrorMessage.Add(ex.Message);
                return UnprocessableEntity(_response);
            }
            return null;
        }
        [HttpGet("GetUser")]
        public async Task<APIResponse> GetUserByUsername(string username)
        {
           var user = await _userRepository.GetUserByUsername(username);
            if(user is null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("Utente non trovato");
                return _response;
            }
            _response.StatusCode=HttpStatusCode.OK;
            _response.Result =user;
            _response.IsSuccess = true;
            return _response;
        }
        [HttpPut("EditUserNameAndLastname")]
        public async Task<APIResponse> EditNameAndLastnameOfUser (UserDTO user)
        {
            try
            {
                await _userRepository.EditNameAndLastnameOfUser(user);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = user;
                return _response;
            }
            catch (Exception ex)
            {
                _response.ErrorMessage.Add(ex.ToString());
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return _response;
            }

        }
    }
}
