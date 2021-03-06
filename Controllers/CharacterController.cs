using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Controllers
{
    [Authorize]
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
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _characterService.GetById(id));
        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] CharacterEditDto character)
        => Ok(await _characterService.Edit(character));
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _characterService.Delete(id);
            return Ok("record deleted successfully");
        }

    }
}