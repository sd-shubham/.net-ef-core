using AutoMapper;
using CoreAPIAndEfCore.Enum;
using CoreAPIAndEfCore.MapperConfig;
using CoreAPIAndEfCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreAPIAndEfCore.Dtos
{
    public class CharacterGetDto : IMapFrom<Character>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgType RpgType { get; set; }
        public GetWeaponDto Weapon { get; set; }
        public IEnumerable<GetSkillDto> Skills { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Character, CharacterGetDto>()
                .ForMember(dto => dto.Skills, c => c.MapFrom(c => c.CharacterSkills.Select(s => s.Skill)));
        }

    }
   
}