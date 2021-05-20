using System.ComponentModel.DataAnnotations;
using CoreAPIAndEfCore.Enum;
namespace CoreAPIAndEfCore.Models
{
    public class Character
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgType RpgType { get; set; }
    }
}