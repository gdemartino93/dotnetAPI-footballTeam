using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetAPI_Rubrica.Models.DTO
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRequestDTO : ControllerBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
