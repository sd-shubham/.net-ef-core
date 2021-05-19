using CoreAPIAndEfCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterservice) => _characterService = characterservice;
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _characterService.GetAllCharacter());

        // [HttpGet("get-by-id/{id}")]
        // public IActionResult GetById(int id)
        // {
        //     return Ok(_character[1]);
        // }

    }
}