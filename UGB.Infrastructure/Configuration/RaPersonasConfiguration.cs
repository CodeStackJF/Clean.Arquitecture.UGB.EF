using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class RaPersonasConfiguration : IEntityTypeConfiguration<ra_per_personas>
    {
        public void Configure(EntityTypeBuilder<ra_per_personas> builder)
        {
            builder.HasKey(x=>x.per_codigo);
            builder.HasOne(x=>x.ra_pla_planes).WithMany().HasForeignKey(x=>x.per_codpla);
        }

    }
}