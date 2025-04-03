using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class RaPlanesConfiguration : IEntityTypeConfiguration<ra_pla_planes>
    {
        public void Configure(EntityTypeBuilder<ra_pla_planes> builder)
        {
            builder.HasKey(x=>x.pla_codigo);
            builder.HasOne(x=>x.ra_car_carreras).WithMany(x=>x.ra_pla_planes).HasForeignKey(x=>x.pla_codcar);
        }

    }
}