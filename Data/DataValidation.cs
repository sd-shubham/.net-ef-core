using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreAPIAndEfCore.Common;
using Microsoft.EntityFrameworkCore;

namespace CoreAPIAndEfCore.Data
{
    public interface IDataValidation<Entity> where Entity : class
    {
        Task<Entity> CheckEntityExistsById(Expression<Func<Entity, bool>> predicate);
    }

    public class DataValidation<Entity> : IDataValidation<Entity> where Entity : class
    {
        private readonly DataContext _dbContext;
        private DbSet<Entity> EntitySet => _dbContext.Set<Entity>();

        public DataValidation(DataContext dbContext) => _dbContext = dbContext;
        public async Task<Entity> CheckEntityExistsById(Expression<Func<Entity, bool>> predicate) =>
         await EntitySet.FirstOrDefaultAsync(predicate);

    }
}