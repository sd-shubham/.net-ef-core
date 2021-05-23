using AutoMapper;
using CoreAPIAndEfCore.Data;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Services
{
    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dbContext;

        public SkillService(DataContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<CreateSkillDto> Create(CreateSkillDto skillDto)
        {
            await _dbContext.Skills.AddAsync(_mapper.Map<Skill>(skillDto));
            await _dbContext.SaveChangesAsync();
            return skillDto;
        }
    }
}
