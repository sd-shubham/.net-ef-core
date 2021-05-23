using AutoMapper;
using CoreAPIAndEfCore.Data;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
namespace CoreAPIAndEfCore.Services
{
    public class CharacterSkillService: ICharacterSkillService
    {
        private readonly IMapper mapper;
        private readonly IServiceContext serviceContext;
        private readonly DataContext dataContext;

        public CharacterSkillService(IMapper mapper,IServiceContext serviceContext, DataContext dataContext)
        {
            this.mapper = mapper;
            this.serviceContext = serviceContext;
            this.dataContext = dataContext;
        }
        public async Task<CharacterGetDto> Create(CreateCharacterSkillRequestDto characterSkillDto)
        {
            var character = await dataContext.characters.Include(w => w.Weapon)
                            .Include(cs => cs.CharacterSkills).ThenInclude(s => s.Skill)
                            .FirstOrDefaultAsync(c => c.Id == characterSkillDto.CharacterId && c.UserId == serviceContext.UserId);
            if (character is null)
                throw new InvalidOperationException("can not add skill. requested character does not exists");
            var skill = await dataContext.Skills.FirstOrDefaultAsync(x => x.Id == characterSkillDto.SkillId);
            if (skill is null)
                throw new InvalidOperationException("can not add skill. requested skill does not exists");
            var characterSkill = new CharacterSkill
            {
                Character = character,
                Skill = skill
            };
            await dataContext.CharacterSkills.AddAsync(characterSkill);
            await dataContext.SaveChangesAsync();
            return mapper.Map<CharacterGetDto>(character);
        } 
    }
}
