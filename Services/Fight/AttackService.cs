using CoreAPIAndEfCore.Common.CustomException;
using CoreAPIAndEfCore.Data;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Services
{
    public class AttackService : IAttackService
    {
        private readonly DataContext _dataContext;

        public AttackService(DataContext dataContext) => _dataContext = dataContext;

        public async Task<FightResultDto> Fight(FightRequestDto requestDto)
        {
            var character = await _dataContext.characters.Include(w => w.Weapon)
                            .Include(cs => cs.CharacterSkills).ThenInclude(s => s.Skill)
                            .Where(x => requestDto.CharacterIds.Contains(x.Id)).ToListAsync();
            bool defeted = false;
            var result = new FightResultDto();
            while (!defeted)
            {
                foreach (var attacker in character)
                {
                    var opponents = character.Where(c => c.Id != attacker.Id).ToList();
                    var opponent = opponents[new Random().Next(opponents.Count)];
                    int damage = 0;
                    string attackUsed = string.Empty;
                    bool useWeapon = new Random().Next(2) == 0;
                    if (useWeapon)
                    {
                        attackUsed = attacker.Weapon.Name;
                        damage = DoWeaponAttack(attacker, opponent);
                    }
                    else
                    {
                        int randomSkill = new Random().Next(attacker.CharacterSkills.ToList().Count);
                        attackUsed = attacker.CharacterSkills.ToList()[randomSkill].Skill.Name;
                        damage = DoSkillAttack(attacker, opponent, attacker.CharacterSkills.ToList()[randomSkill]);
                    }
                    result.Log.Add(@$"{attacker.Name} attacks {opponent.Name} using {attackUsed} with {(damage >= 0 ? damage : 0)} damage");
                    if (opponent.HitPoints <= 0)
                    {
                        defeted = true;
                        attacker.Victories++;
                        opponent.Defeats++;
                        result.Log.Add($"{opponent.Name} has been defeted");
                        result.Log.Add($"{attacker.Name} wins with {attacker.HitPoints} HP Limit");
                        break;
                    }
                }
            }
            character.ForEach(c =>
            {
                c.Fights++;
                c.HitPoints = 100;
            });
            _dataContext.UpdateRange(character);
            await _dataContext.SaveChangesAsync();
            return result;
        }

        public async Task<AttackResultDto> SkillAttack(SkillAttackDto attackDto)
        {
            var attacker = await _dataContext.characters.Include(cs => cs.CharacterSkills)
                          .ThenInclude(s => s.Skill).FirstOrDefaultAsync(c => c.Id == attackDto.AttackerId);
            if (attacker is null) throw new RecordNotFoundException("Attacker not found");
            var opponent = await _dataContext.characters.FirstOrDefaultAsync(c => c.Id == attackDto.OpponentId);
            if (opponent is null) throw new RecordNotFoundException("Opponent not found");
            string result = string.Empty;
            CharacterSkill characterSkill = attacker.CharacterSkills.FirstOrDefault(x => x.SkillId == attackDto.SkillId);
            if (characterSkill is null) throw new RecordNotFoundException($"{attacker.Name} doesn't know to that skill");
            int damage = DoSkillAttack(attacker, opponent, characterSkill);
            if (opponent.HitPoints <= 0) result = $"{opponent.Name} has been defeted";
            _dataContext.characters.Update(opponent);
            await _dataContext.SaveChangesAsync();
            return new AttackResultDto
            {
                Attacker = attacker.Name,
                Opponent = opponent.Name,
                AttackerHP = attacker.HitPoints,
                OpponentHP = opponent.HitPoints,
                Damage = damage,
                Finalresult = string.IsNullOrEmpty(result) ? "" : result
            };
        }

        private static int DoSkillAttack(Character attacker, Character opponent, CharacterSkill characterSkill)
        {
            int damage = characterSkill.Skill.Damage + (new Random().Next(attacker.Intelligence));
            damage -= new Random().Next(opponent.Defense);
            if (damage > 0) opponent.HitPoints -= damage;
            return damage;
        }

        public async Task<AttackResultDto> WeaponAttack(WeaponAttackDto attackDto)
        {
            var attacker = await _dataContext.characters.Include(w => w.Weapon)
                            .FirstOrDefaultAsync(c => c.Id == attackDto.AttackerId);
            if (attacker is null) throw new RecordNotFoundException("Attacker not found");
            var opponent = await _dataContext.characters.Include(w => w.Weapon)
                            .FirstOrDefaultAsync(c => c.Id == attackDto.OpponentId);
            if (opponent is null) throw new RecordNotFoundException("Opponent not found");
            string result = string.Empty;
            int damage = DoWeaponAttack(attacker, opponent);
            if (opponent.HitPoints <= 0) result = $"{opponent.Name} has been defeted";
            _dataContext.characters.Update(opponent);
            await _dataContext.SaveChangesAsync();
            return new AttackResultDto
            {
                Attacker = attacker.Name,
                Opponent = opponent.Name,
                AttackerHP = attacker.HitPoints,
                OpponentHP = opponent.HitPoints,
                Damage = damage,
                Finalresult = string.IsNullOrEmpty(result) ? "" : result
            };
        }

        private int DoWeaponAttack(Character attacker, Character opponent)
        {
            int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
            damage -= new Random().Next(opponent.Defense);
            if (damage > 0) opponent.HitPoints -= damage;
            return damage;
        }
    }
}
