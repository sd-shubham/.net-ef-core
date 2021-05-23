using CoreAPIAndEfCore.Common;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Services
{
  public  interface ICharacterSkillService: IScopedService
    {
        Task<CharacterGetDto> Create(CreateCharacterSkillRequestDto characterSkillDto);
    }
}
