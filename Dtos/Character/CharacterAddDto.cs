using System.ComponentModel.DataAnnotations;
using CoreAPIAndEfCore.Enum;

namespace CoreAPIAndEfCore.Dtos
{
    public class CharacterAddDto
    {
        [Required(ErrorMessage = "name is requird")]
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgType RpgType { get; set; }
    }
}