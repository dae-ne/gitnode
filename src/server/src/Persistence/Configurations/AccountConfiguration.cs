using GitNode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitNode.Persistence.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder
                .Property(a => a.UserId)
                .IsRequired();
            
            builder
                .Property(a => a.PlatformId)
                .IsRequired();
        }
    }
}