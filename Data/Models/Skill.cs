using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.MapperConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Models
{
    public class Skill: IMapFrom<CreateSkillDto>
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Damage { get; set; }
        public IEnumerable<CharacterSkill> CharacterSkills { get; set; }
    }
}
