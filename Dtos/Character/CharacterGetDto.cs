using CoreAPIAndEfCore.Enum;

namespace CoreAPIAndEfCore.Dtos
{
    public class CharacterGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgType RpgType { get; set; }
        public GetWeaponDto Weapon { get; set; }
    }
}