using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Dtos
{
    public class CreateCharacterSkillRequestDto
    {
        public int CharacterId { get; set; }
        public int SkillId { get; set; }

    }
}
