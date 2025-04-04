using Microsoft.EntityFrameworkCore;
using UGB.Domain.Entities;
using UGB.Domain.Primitives;
using UGB.Infrastructure.Interfaces;

namespace UGB.Infrastructure
{
    public class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        
        public DbSet<ra_car_carreras> ra_car_carreras { get; set; }
        public DbSet<ra_cil_ciclo> ra_cil_ciclo { get; set; }
        public DbSet<ra_hor_horarios> ra_hor_horarios { get; set; }
        public DbSet<ra_ins_inscripcion> ra_ins_inscripcion { get; set; }
        public DbSet<ra_mat_materias> ra_mat_materias { get; set; }
        public DbSet<ra_per_personas> ra_per_personas { get; set; }
        public DbSet<ra_pla_planes> ra_pla_planes { get; set; }
        public DbSet<ra_plm_planes_materias> ra_plm_planes_materias { get; set; }
        public DbSet<http_logs> http_logs { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<signal_r_sessions> signal_r_sessions { get; set; }
    }
}