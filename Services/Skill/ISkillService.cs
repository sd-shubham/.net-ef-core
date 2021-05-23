using CoreAPIAndEfCore.Common;
using CoreAPIAndEfCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Services
{
   public interface ISkillService: IScopedService
    {
        Task<CreateSkillDto> Create(CreateSkillDto skill);
    }
}
