using CoreAPIAndEfCore.Common;
using CoreAPIAndEfCore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Services
{
   public interface IAttackService:IScopedService
    {
        Task<AttackResultDto> WeaponAttack(WeaponAttackDto attackDto);
        Task<AttackResultDto> SkillAttack(SkillAttackDto attackDto);
        Task<FightResultDto> Fight(FightRequestDto requestDto);
        Task<IEnumerable<HighScoreDto>> GetHightScore();
    }
}
