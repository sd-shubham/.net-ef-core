using CoreAPIAndEfCore.Dtos;
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

        [HttpPost("add-character")]
        public async Task<IActionResult> Add([FromBody] CharacterAddDto character)
        => Ok(await _characterService.Create(character));

    }
}