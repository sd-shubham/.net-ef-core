using CoreAPIAndEfCore.Common;
using CoreAPIAndEfCore.Dtos;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Services
{
   public interface IAttackService:IScopedService
    {
        Task<AttackResultDto> WeaponAttack(WeaponAttackDto attackDto);
        Task<AttackResultDto> SkillAttack(SkillAttackDto attackDto);
        Task<FightResultDto> Fight(FightRequestDto requestDto);
    }
}
