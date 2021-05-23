using CoreAPIAndEfCore.MapperConfig;
using CoreAPIAndEfCore.Models;

namespace CoreAPIAndEfCore.Dtos
{
    public class GetWeaponDto: IMapFrom<Weapon>
    {
        public string Name { get; set; }
        public int Damage { get; set; }

    }
}