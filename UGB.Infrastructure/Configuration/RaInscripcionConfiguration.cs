using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class RaInscripcionConfiguration : IEntityTypeConfiguration<ra_ins_inscripcion>
    {
        public void Configure(EntityTypeBuilder<ra_ins_inscripcion> builder)
        {
            builder.HasKey(x=>x.ins_codigo);
        }

    }
}