using CoreAPIAndEfCore.Models;
using CoreAPIAndEfCore.Services;
using Microsoft.EntityFrameworkCore;

namespace CoreAPIAndEfCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Character> characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>()
                .HasKey(cs => new { cs.CharacterId, cs.SkillId });
            modelBuilder.Entity<User>()
                .Property(user => user.Role).HasDefaultValue("Player");
           // base.OnModelCreating(modelBuilder);
        }
    }
}