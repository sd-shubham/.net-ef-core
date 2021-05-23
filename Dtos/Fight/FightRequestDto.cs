using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Dtos
{
    public class FightRequestDto
    {
        public IEnumerable<int> CharacterIds { get; set; }
    }
}
