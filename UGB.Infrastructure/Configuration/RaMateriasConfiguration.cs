using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Configuration
{
    public class RaMateriasConfiguration : IEntityTypeConfiguration<ra_mat_materias>
    {
        public void Configure(EntityTypeBuilder<ra_mat_materias> builder)
        {
            builder.HasKey(x=>x.mat_codigo);
            builder.Property(x=>x.mat_codigo).ValueGeneratedNever();
        }
    }
}