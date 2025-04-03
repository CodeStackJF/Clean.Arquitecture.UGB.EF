using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<users>
    {
        public void Configure(EntityTypeBuilder<users> builder)
        {
            builder.HasKey(x=>x.id);
        }

    }
}