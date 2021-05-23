using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Dtos
{
    public class SaveCharacterSkillDto
    {
        public CharacterGetDto Character { get; set; }
        public GetSkillDto Skill { get; set; }
    }
}
