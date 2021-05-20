using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreAPIAndEfCore.Attributes;
using CoreAPIAndEfCore.Data;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task<CharacterGetDto> GetById(int id)
        {
            var character = await _dbContext.characters.FirstOrDefaultAsync(x => x.Id == id);
            if (character is null)
                throw new InvalidOperationException($"no record found with id {id}");
            return _mapper.Map<CharacterGetDto>(character);
        }
        public async Task<CharacterGetDto> Edit(CharacterEditDto characterDto)
        {
            var character = await _dbContext.characters.FirstOrDefaultAsync(x => x.Id == characterDto.Id);
            if (character is null)
                throw new InvalidOperationException($"no record found with id {characterDto.Id}");
            _mapper.Map(characterDto, character);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CharacterGetDto>(character);
        }
        public async Task Delete(int id)
        {
            var character = await _dbContext.characters.FirstOrDefaultAsync(x => x.Id == id);
            if (character is null)
                throw new InvalidOperationException($"no record found with id {id}");
            _dbContext.Remove(character);
            await _dbContext.SaveChangesAsync();

        }
    }

}