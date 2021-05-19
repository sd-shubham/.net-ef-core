using System.Threading.Tasks;
using System.Collections.Generic;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Common;

namespace CoreAPIAndEfCore.Services
{
    public interface ICharacterService : IScopedService
    {

        Task<IEnumerable<CharacterGetDto>> GetAllCharacter();
    }
}