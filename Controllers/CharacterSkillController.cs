using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterSkillController: ControllerBase
    {
        private readonly ICharacterSkillService _chracterSkillService;
        public CharacterSkillController(ICharacterSkillService characterSkillService) =>
            _chracterSkillService = characterSkillService;
        [HttpPost]
       public async Task<IActionResult> Create(CreateCharacterSkillRequestDto requestDto)
            => Ok(await _chracterSkillService.Create(requestDto));
    }
}
