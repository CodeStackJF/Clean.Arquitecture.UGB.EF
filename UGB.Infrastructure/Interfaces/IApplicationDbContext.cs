using Microsoft.EntityFrameworkCore;
using UGB.Domain.Entities;

namespace UGB.Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ra_car_carreras> ra_car_carreras { get; set; }
        DbSet<ra_cil_ciclo> ra_cil_ciclo { get; set; }
        DbSet<ra_hor_horarios> ra_hor_horarios { get; set; }
        DbSet<ra_ins_inscripcion> ra_ins_inscripcion { get; set; }
        DbSet<ra_mat_materias> ra_mat_materias { get; set; }
        DbSet<ra_per_personas> ra_per_personas { get; set; }
        DbSet<ra_pla_planes> ra_pla_planes { get; set; }
        DbSet<ra_plm_planes_materias> ra_plm_planes_materias { get; set; }
        DbSet<users> users { get; set; }
        DbSet<http_logs> http_logs { get; set; }
        DbSet<signal_r_sessions> signal_r_sessions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
    }
}