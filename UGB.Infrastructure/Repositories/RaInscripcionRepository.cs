using Microsoft.EntityFrameworkCore;
using UGB.Application.Data;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class RaInscripcionRepository : IRaInscripcionRepository
    {
        private readonly IApplicationDbContext ctx;
        public RaInscripcionRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }
        
        public async Task<ra_ins_inscripcion> Create(ra_ins_inscripcion inscripcion)
        {
            ctx.ra_ins_inscripcion.Add(inscripcion);
            await ctx.SaveChangesAsync();
            return inscripcion;
        }

        public async Task<ra_ins_inscripcion> Get(int id)
        {
            return (await ctx.ra_ins_inscripcion.Include(x=>x.ra_hor_horarios.ra_cil_ciclo)
                                                .Include(x=>x.ra_hor_horarios.ra_plm_planes_materias.ra_mat_materias)
                                                .Where(x=>x.ins_codigo == id).FirstOrDefaultAsync())!;
        }

        public async Task<IEnumerable<ra_ins_inscripcion>> GetAllByCicloEstudiante(int codcil, int codper)
        {
            return await ctx.ra_ins_inscripcion.Include(x=>x.ra_hor_horarios.ra_plm_planes_materias.ra_mat_materias).Where(x=>x.ra_hor_horarios.hor_codcil == codcil && x.ins_codper == codper).ToListAsync();
        }

        public async Task<IEnumerable<ra_ins_inscripcion>> GetAllByEstudiante(int codper)
        {
            return await ctx.ra_ins_inscripcion.Include(x=>x.ra_hor_horarios.ra_plm_planes_materias.ra_mat_materias).Where(x=>x.ins_codper == codper).ToListAsync();
        }

        public async Task<bool> Update(int id, ra_ins_inscripcion ciclo)
        {
            ctx.ra_ins_inscripcion.Update(ciclo);
            return await ctx.SaveChangesAsync() == 1;
        }

    }
}