using CoreAPIAndEfCore.MapperConfig;
using CoreAPIAndEfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Dtos
{
    public class GetSkillDto:IMapFrom<Skill>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
    }
}
