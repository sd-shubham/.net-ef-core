using AutoMapper;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;

namespace CoreAPIAndEfCore.MapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterGetDto>();
            CreateMap<CharacterAddDto, Character>();
            CreateMap<CharacterEditDto, Character>();
        }
    }
}