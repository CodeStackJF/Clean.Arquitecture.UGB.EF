using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Application.Configuration
{
    public class HttpLogsConfiguration : IEntityTypeConfiguration<http_logs>
    {
        public void Configure(EntityTypeBuilder<http_logs> builder)
        {
            builder.HasKey(x=>x.id);
        }

    }
}