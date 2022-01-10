using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitNode.Persistence.Configurations
{
    internal class PlatformConfiguration : IEntityTypeConfiguration<PlatformEntity>
    {
        public void Configure(EntityTypeBuilder<PlatformEntity> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}