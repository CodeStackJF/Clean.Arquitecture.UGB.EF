using System.Linq;
using Microsoft.EntityFrameworkCore;
using UGB.Application.Data;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class RaCarrerasRepository : IRaCarrerasRepository
    {
        private readonly IApplicationDbContext ctx;
        public RaCarrerasRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }
        
        public async Task<ra_car_carreras> Create(ra_car_carreras carrera)
        {
            ctx.ra_car_carreras.Add(carrera);
            await ctx.SaveChangesAsync();
            return carrera;
        }

        public async Task<bool> ExistsName(int id, string name)
        {
            return await ctx.ra_car_carreras.AnyAsync(x=>x.car_nombre == name && x.car_codigo != id);
        }

        public async Task<bool> Exists(int id)
        {
            return await ctx.ra_car_carreras.AnyAsync(x=>x.car_codigo == id);
        }

        public async Task<ra_car_carreras> Get(int id)
        {
            return (await ctx.ra_car_carreras.FindAsync(id))!;
        }

        public async Task<IEnumerable<ra_car_carreras>> GetAll()
        {
            return await ctx.ra_car_carreras.ToListAsync();
        }

        public async Task<IEnumerable<ra_car_carreras>> GetAllWithPlanes()
        {
            return await ctx.ra_car_carreras.Include(x=>x.ra_pla_planes).ToListAsync();
        }

        public async Task<ra_car_carreras> GetWithPlanes(int id)
        {
            return (await ctx.ra_car_carreras.Include(x=>x.ra_pla_planes).Where(x=>x.car_codigo == id).FirstOrDefaultAsync())!;
        }


        public async Task<IEnumerable<ra_car_carreras>> Search(string searchTerm)
        {
            return await ctx.ra_car_carreras.Where(x=>x.car_nombre.Contains(searchTerm)).ToListAsync();
        }

        public async Task<bool> Update(int id, ra_car_carreras carrera)
        {
            ctx.ra_car_carreras.Update(carrera);
            return await ctx.SaveChangesAsync() == 1;
        }

        public async Task Delete(int id)
        {
            var result = await Get(id);
            ctx.ra_car_carreras.Remove(result);
            await ctx.SaveChangesAsync();
        }

    }
}