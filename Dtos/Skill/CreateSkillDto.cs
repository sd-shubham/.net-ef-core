using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Dtos
{
    public class CreateSkillDto
    {
        [Required]
        public string Name { get; set; }
        public int Damage { get; set; }

    }
}
