using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class RaCicloConfiguration : IEntityTypeConfiguration<ra_cil_ciclo>
    {
        public void Configure(EntityTypeBuilder<ra_cil_ciclo> builder)
        {
            builder.HasKey(x=>x.cil_codigo);
        }

    }
}