using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class SignalRConfiguration : IEntityTypeConfiguration<signal_r_sessions>
    {
        public void Configure(EntityTypeBuilder<signal_r_sessions> builder)
        {
            builder.HasKey(x=>x.username);
        }

    }
}