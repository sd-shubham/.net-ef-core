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
    public class AttackController: ControllerBase
    {
        private readonly IAttackService _attackerService;

        public AttackController(IAttackService attackService) => _attackerService = attackService;
        [HttpPost("weapon")]
        public async Task<IActionResult> WeaponFight(WeaponAttackDto attackDto)
            => Ok(await _attackerService.WeaponAttack(attackDto));
        [HttpPost("skill")]
        public async Task<IActionResult> SkillFight(SkillAttackDto attackDto)
           => Ok(await _attackerService.SkillAttack(attackDto));
        [HttpPost]
        public async Task<IActionResult> Fight(FightRequestDto attackDto)
          => Ok(await _attackerService.Fight(attackDto));
    }
}
