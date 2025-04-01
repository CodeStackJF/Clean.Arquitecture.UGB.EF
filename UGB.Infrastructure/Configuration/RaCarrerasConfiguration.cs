using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class RaCarrerasConfiguration : IEntityTypeConfiguration<ra_car_carreras>
    {
        public void Configure(EntityTypeBuilder<ra_car_carreras> builder)
        {
            builder.HasKey(x=>x.car_codigo);
            builder.HasMany(x=>x.ra_pla_planes).WithOne(x=>x.ra_car_carreras).HasForeignKey(x=>x.pla_codcar);
        }
    }
}