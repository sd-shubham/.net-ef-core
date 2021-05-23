using System.ComponentModel.DataAnnotations;

namespace CoreAPIAndEfCore.Dtos
{
    public class WeaponAddDto
    {
        [Required]
        public int CharacterId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Damage { get; set; }
    }
}