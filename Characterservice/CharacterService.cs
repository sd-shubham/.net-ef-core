using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreAPIAndEfCore.Attributes;
using CoreAPIAndEfCore.Common;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;

namespace CoreAPIAndEfCore.Services
{
    [Injectable]
    public class CharacterService : ICharacterService
    {
        private Character _character;
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _character = new Character();
            _mapper = mapper;
        }
        public async Task<IEnumerable<CharacterGetDto>> GetAllCharacter()
        {
            var characters = new List<Character>{
                new Character()
            };
            return await Task.FromResult(_mapper.Map<IEnumerable<CharacterGetDto>>(characters));
        }
    }

}