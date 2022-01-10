using System.Reflection;
using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitNode.Persistence
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<UserEntity> Users { get; set; }
        
        public DbSet<PlatformEntity> Platforms { get; set; }
        
        public DbSet<AccountEntity> Accounts { get; set; }
        
        public DbSet<RepoEntity> Repos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}