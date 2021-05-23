using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Dtos
{
    public class AttackResultDto
    {
        public string Attacker { get; set; }
        public string Opponent { get; set; }
        public int AttackerHP { get; set; }
        public int OpponentHP { get; set; }
        public string Finalresult { get; set; }
        public int Damage { get; set; }

    }
}
