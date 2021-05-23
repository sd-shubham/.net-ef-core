using CoreAPIAndEfCore.Common;
using CoreAPIAndEfCore.Dtos;
using System.Threading.Tasks;
namespace CoreAPIAndEfCore.Services
{
    public interface IWeaponService : IScopedService
    {
        public Task<CharacterGetDto> Add(WeaponAddDto weapon);
    }
}