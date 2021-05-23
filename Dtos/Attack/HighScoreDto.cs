using CoreAPIAndEfCore.MapperConfig;
using CoreAPIAndEfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Dtos
{
    public class HighScoreDto: IMapFrom<Character>
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}
