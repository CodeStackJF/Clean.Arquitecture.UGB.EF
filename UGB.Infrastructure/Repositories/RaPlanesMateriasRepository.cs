using Microsoft.EntityFrameworkCore;
using UGB.Application.Data;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class RaPlanesMateriasRepository : IRaPlanesMateriasRepository
    {
        private readonly IApplicationDbContext ctx;
        public RaPlanesMateriasRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }
        
        public async Task<ra_plm_planes_materias> Create(ra_plm_planes_materias plan)
        {
            ctx.ra_plm_planes_materias.Add(plan);
            await ctx.SaveChangesAsync();
            return plan;
        }

        public async Task<ra_plm_planes_materias> Get(int codpla, string codmat)
        {
            return (await ctx.ra_plm_planes_materias.Include(x=>x.ra_mat_materias).Include(x=>x.ra_pla_planes).Where(x=>x.plm_codpla == codpla && x.plm_codmat == codmat).FirstOrDefaultAsync())!;
        }

        public async Task<IEnumerable<ra_plm_planes_materias>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ra_plm_planes_materias>> GetByPlan(int codpla)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ra_plm_planes_materias>> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(int codpla, string codmat, ra_plm_planes_materias plan)
        {
            throw new NotImplementedException();
        }

    }
}