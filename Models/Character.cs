using CoreAPIAndEfCore.Enum;
namespace CoreAPIAndEfCore.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Paul";
        public int HitPoints { get; set; } = 40;
        public int Strength { get; set; } = 50;
        public int Defense { get; set; } = 20;
        public int Intelligence { get; set; } = 10;
        public RpgType RpgType { get; set; } = RpgType.claric;
    }
}