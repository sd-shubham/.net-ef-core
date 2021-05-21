using System.Threading.Tasks;
using AutoMapper;
using CoreAPIAndEfCore.Data;
using CoreAPIAndEfCore.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using CoreAPIAndEfCore.Models;

namespace CoreAPIAndEfCore.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly IMapper _mapper;
        private readonly IServiceContext _serviceContext;
        private readonly DataContext _dataContext;
        public WeaponService(IMapper mapper, IServiceContext serviceContext, DataContext dataContext)
        {
            _dataContext = dataContext;
            _serviceContext = serviceContext;
            _mapper = mapper;

        }
        public async Task<CharacterGetDto> Add(WeaponAddDto weaponDto)
        {
            var character = await _dataContext.characters.FirstOrDefaultAsync(x => x.Id == weaponDto.CharacterId && x.UserId == _serviceContext.UserId);
            if (character is null) throw new InvalidOperationException(
                 "can not add wapon beacuse requested character doesn't exits"
             );
            var waepon = _mapper.Map<Weapon>(weaponDto);
            waepon.character = character;
            await _dataContext.Weapons.AddAsync(waepon);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<CharacterGetDto>(character);
        }
    }
}