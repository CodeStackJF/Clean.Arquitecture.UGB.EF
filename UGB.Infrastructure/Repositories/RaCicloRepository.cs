using Microsoft.EntityFrameworkCore;
using UGB.Application.Data;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class RaCicloRepository : IRaCicloRepository
    {
        private readonly IApplicationDbContext ctx;
        public RaCicloRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<ra_cil_ciclo> Get(int id)
        {
            return (await ctx.ra_cil_ciclo.FindAsync(id))!;
        }

        public async Task<ra_cil_ciclo?> GetActive()
        {
            return (await ctx.ra_cil_ciclo.Where(x=>x.cil_vigente).FirstOrDefaultAsync())!;
        }

        public async Task<IEnumerable<ra_cil_ciclo>> GetAll()
        {
            return await ctx.ra_cil_ciclo.ToListAsync();
        }

    }
}