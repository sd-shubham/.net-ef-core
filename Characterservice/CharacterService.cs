using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreAPIAndEfCore.Attributes;
using CoreAPIAndEfCore.Common;
using CoreAPIAndEfCore.Data;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAPIAndEfCore.Services
{
    [Injectable]
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper, DataContext dbContext)
        => (_mapper, _dbContext) = (mapper, dbContext);
        public async Task<IEnumerable<CharacterGetDto>> GetAllCharacter()
        => _mapper.Map<IEnumerable<CharacterGetDto>>(await _dbContext.characters.ToListAsync());

        public async Task<CharacterAddDto> Create(CharacterAddDto character)
        {
            await _dbContext.characters.AddAsync(_mapper.Map<Character>(character));
            await _dbContext.SaveChangesAsync();
            return character;
        }
    }

}