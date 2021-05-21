using AutoMapper;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;

namespace CoreAPIAndEfCore.MapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Character Map
            CreateMap<Character, CharacterGetDto>();
            CreateMap<CharacterAddDto, Character>();
            CreateMap<CharacterEditDto, Character>();
            // User map
            CreateMap<UserCreateDto, Uesr>();

            // Weapon Map
            CreateMap<WeaponAddDto, Weapon>();
            CreateMap<Weapon, GetWeaponDto>();
        }
    }
}