using Microsoft.EntityFrameworkCore;
using UGB.Application.Data;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class RaHorariosRepository : IRaHorariosRepository
    {
        private readonly IApplicationDbContext ctx;
        public RaHorariosRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<ra_hor_horarios> Create(ra_hor_horarios ciclo)
        {
            ctx.ra_hor_horarios.Add(ciclo);
            await ctx.SaveChangesAsync();
            return ciclo;
        }

        public async Task<ra_hor_horarios> Get(int id)
        {
            return (await ctx.ra_hor_horarios.Include(x=>x.ra_plm_planes_materias.ra_mat_materias).Where(x=>x.hor_codigo == id).FirstOrDefaultAsync())!;
        }

        public async Task<IEnumerable<ra_hor_horarios>> GetAll()
        {
            return await ctx.ra_hor_horarios.Include(x=>x.ra_plm_planes_materias.ra_mat_materias).ToListAsync();
        }

        public async Task<IEnumerable<ra_hor_horarios>> GetAllByPlanMateria(int codcil, int codpla, string codmat)
        {
            return await ctx.ra_hor_horarios.Include(x=>x.ra_plm_planes_materias.ra_mat_materias).Where(x=>x.hor_codcil == codcil && x.hor_codpla == codpla && x.hor_codmat == codmat).ToListAsync();
        }

        public async Task<bool> Update(int id, ra_hor_horarios ciclo)
        {
            ctx.ra_hor_horarios.Update(ciclo);
            return await ctx.SaveChangesAsync() == 1;
        }

        public async Task<bool> ExistsHorario(int codhor, int codcil, int codpla, String codmat, string grupo)
        {
            return await ctx.ra_hor_horarios.AnyAsync(x=>x.hor_codcil == codcil && x.hor_codpla == codpla && x.hor_codmat == codmat && x.hor_grupo == grupo && x.hor_codigo != codhor);
        }

    }
}