using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitNode.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .Property(u => u.Email)
                .HasMaxLength(65)
                .IsRequired();

            builder
                .Property(u => u.CreatedAt)
                .IsRequired();
        }
    }
}