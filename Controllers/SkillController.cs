using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        public readonly ISkillService _skillService;
        public SkillController(ISkillService skillService) => _skillService = skillService;
        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillDto skillDto)
            => Ok(await _skillService.Create(skillDto));
    }
}
