using dotnetAPI_Rubrica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetAPI_Rubrica.Controllers.v1
{
    [Route("api/v{versione:apiVersion}")]
    [ApiController]
    public class Contacts : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetApartments()
        {
            return "asd";
        }
    }
}
