using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class RaHorariosConfiguration : IEntityTypeConfiguration<ra_hor_horarios>
    {
        public void Configure(EntityTypeBuilder<ra_hor_horarios> builder)
        {
            builder.HasKey(x=>x.hor_codigo);
        }

    }
}