using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.MapperConfig;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAPIAndEfCore.Models
{
    public class Weapon: IMapFrom<WeaponAddDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public Character character { get; set; }
        [ForeignKey(nameof(character))]
        public int CharacterId { get; set; }
    }
}