using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class RaPlanesMateriasConfiguration : IEntityTypeConfiguration<ra_plm_planes_materias>
    {
        public void Configure(EntityTypeBuilder<ra_plm_planes_materias> builder)
        {
            builder.HasKey(x=>new {
                x.plm_codpla,
                x.plm_codmat
            });
        }

    }
}