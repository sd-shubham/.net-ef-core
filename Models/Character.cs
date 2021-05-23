using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Enum;
using CoreAPIAndEfCore.MapperConfig;

namespace CoreAPIAndEfCore.Models
{
    public class Character : IMapFrom<CharacterAddDto>
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgType RpgType { get; set; }
        public Uesr User { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public Weapon Weapon { get; set; }
        public IEnumerable<CharacterSkill> CharacterSkills { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CharacterAddDto, Character>();
            profile.CreateMap<CharacterEditDto, Character>();
        }
    }
}