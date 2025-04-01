using Microsoft.EntityFrameworkCore;
using UGB.Application.Data;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class RaPersonasRepository : IRaPersonasRepository
    {
        private readonly IApplicationDbContext ctx;
        public RaPersonasRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }
        
        public async Task<ra_per_personas> Create(ra_per_personas estudiante)
        {
            await ctx.ra_per_personas.AddAsync(estudiante);
            await ctx.SaveChangesAsync();
            return estudiante;
        }

        public async Task<ra_per_personas> Get(int id)
        {
            return (await ctx.ra_per_personas.Where(x=>x.per_codigo == id).FirstOrDefaultAsync())!;
        }

        public async Task<IEnumerable<ra_per_personas>> GetAll()
        {
            return await ctx.ra_per_personas.ToListAsync();
        }

        public async Task<IEnumerable<ra_per_personas>> Search(string searchTerm)
        {
            return await ctx.ra_per_personas.Where(x=>x.per_nombres.Contains(searchTerm) || x.per_apellidos.Contains(searchTerm) || x.per_carnet.Contains(searchTerm)).ToListAsync();
        }

        public async Task<bool> Update(int id, ra_per_personas estudiante)
        {
            ctx.ra_per_personas.Update(estudiante);
            return await ctx.SaveChangesAsync() == 1;
        }

        public async Task<bool> ExistsCarnet(int id, string carnet)
        {
            return await ctx.ra_per_personas.AnyAsync(x=>x.per_codigo != id && x.per_carnet == carnet);
        }

        public async Task<ra_per_personas> GetWithNestedData(int id)
        {
            return (await ctx.ra_per_personas.Include(x=>x.ra_pla_planes.ra_car_carreras).Where(x=>x.per_codigo == id).FirstOrDefaultAsync())!;
        }
    }
}