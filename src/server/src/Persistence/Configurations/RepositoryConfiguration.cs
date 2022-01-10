using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitNode.Persistence.Configurations
{
    internal class RepositoryConfiguration : IEntityTypeConfiguration<RepoEntity>
    {
        public void Configure(EntityTypeBuilder<RepoEntity> builder)
        {
            builder
                .Property(r => r.AccountId)
                .IsRequired();
            
            builder
                .Property(r => r.Name)
                .HasMaxLength(30)
                .IsRequired();
            
            builder
                .Property(r => r.Private)
                .IsRequired();

            builder
                .HasIndex(r => new { r.Name, r.AccountId })
                .IsUnique();
        }
    }
}