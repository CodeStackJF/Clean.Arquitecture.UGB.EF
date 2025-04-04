using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UGB.Domain.Wrapper;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;
using UGB.Infrastructure.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class RaPersonasRepository : IRaPersonasRepository
    {
        private readonly IApplicationDbContext ctx;
        private readonly IConfiguration config;
        private readonly int RECORDS_PER_PAGE;
        public RaPersonasRepository(IApplicationDbContext _ctx, IConfiguration _config)
        {
            ctx = _ctx;
            config = _config;
            RECORDS_PER_PAGE = Convert.ToInt32(config.GetSection("RECORDS_PER_PAGE").Value);
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

        public async Task<IEnumerable<ra_per_personas>> GetAll(string searchTerm)
        {
            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await ctx.ra_per_personas
                                .Where(
                                    x=>
                                    x.per_carnet.Contains(searchTerm) ||
                                    x.per_nombres.Contains(searchTerm) ||
                                    x.per_apellidos.Contains(searchTerm) ||
                                    x.per_nombres_apellidos.Contains(searchTerm) ||
                                    x.per_apellidos_nombres.Contains(searchTerm)
                                )
                                .ToListAsync();
            }
            else
                return await ctx.ra_per_personas.AsNoTracking().ToListAsync();
        }

        public async Task<PagedResult<ra_per_personas>> GetAllPaged(int pageNumber, string searchTerm)
        {
            IQueryable<ra_per_personas> query = ctx.ra_per_personas.Include(x=>x.ra_pla_planes.ra_car_carreras)
                                .Where(
                                    x=>
                                    x.per_carnet.Contains(searchTerm) ||
                                    x.per_nombres.Contains(searchTerm) ||
                                    x.per_apellidos.Contains(searchTerm) ||
                                    x.per_nombres_apellidos.Contains(searchTerm) ||
                                    x.per_apellidos_nombres.Contains(searchTerm)
                                );
            int totalRecords = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / RECORDS_PER_PAGE);
            var response = new PagedResult<ra_per_personas>(pageNumber, totalPages, RECORDS_PER_PAGE, totalRecords);
            response.records = await query.Skip((pageNumber-1) * RECORDS_PER_PAGE).Take(RECORDS_PER_PAGE).AsNoTracking().ToListAsync();
            return response;
        }

        public async Task<IEnumerable<ra_per_personas>> Search(string searchTerm)
        {
            return await ctx.ra_per_personas.Where(x=>x.per_nombres.Contains(searchTerm) || x.per_apellidos.Contains(searchTerm) || x.per_carnet.Contains(searchTerm)).AsNoTracking().ToListAsync();
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
            return (await ctx.ra_per_personas.Include(x=>x.ra_pla_planes.ra_car_carreras).Where(x=>x.per_codigo == id).AsNoTracking().FirstOrDefaultAsync())!;
        }
    }
}