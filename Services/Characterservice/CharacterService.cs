using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreAPIAndEfCore.Attributes;
using CoreAPIAndEfCore.Data;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CoreAPIAndEfCore.Services
{
    [Injectable]
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IServiceContext _serviceContext;
        public CharacterService(IMapper mapper, DataContext dbContext, IServiceContext serviceContext)
        => (_mapper, _dbContext, _serviceContext) = (mapper, dbContext, serviceContext);
        public async Task<IEnumerable<CharacterGetDto>> GetAllCharacter()
        => _mapper.Map<IEnumerable<CharacterGetDto>>(await _dbContext.characters.Where(x => x.UserId == _serviceContext.UserId).AsNoTracking()
        .ToListAsync());

        public async Task<CharacterGetDto> Create(CharacterAddDto characterAddDto)
        {
            var character = _mapper.Map<Character>(characterAddDto);
            character.UserId = _serviceContext.UserId;
            await _dbContext.characters.AddAsync(character);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CharacterGetDto>(character);
        }
        public async Task<CharacterGetDto> GetById(int id)
        {
            var character = await _dbContext.characters.FirstOrDefaultAsync(x => x.Id == id && x.UserId == _serviceContext.UserId);

            if (character is null)
                throw new InvalidOperationException($"no record found with id {id}");
            return _mapper.Map<CharacterGetDto>(character);
        }
        public async Task<CharacterGetDto> Edit(CharacterEditDto characterDto)
        {
            var character = await _dbContext.characters.FirstOrDefaultAsync(x => x.Id == characterDto.Id && x.UserId == _serviceContext.UserId);
            if (character is null)
                throw new InvalidOperationException($"no record found with id {characterDto.Id}");
            _mapper.Map(characterDto, character);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CharacterGetDto>(character);
        }
        public async Task Delete(int id)
        {
            var character = await _dbContext.characters.FirstOrDefaultAsync(x => x.Id == id && x.UserId == _serviceContext.UserId);
            if (character is null)
                throw new InvalidOperationException($"no record found with id {id}");
            _dbContext.Remove(character);
            await _dbContext.SaveChangesAsync();

        }
    }

}