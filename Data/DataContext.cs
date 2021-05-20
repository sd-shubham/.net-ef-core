using CoreAPIAndEfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAPIAndEfCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Character> characters { get; set; }
    }
}