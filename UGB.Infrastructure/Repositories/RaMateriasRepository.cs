using Microsoft.EntityFrameworkCore;
using UGB.Application.Data;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class RaMateriasRepository : IRaMateriasRepository
    {
        private readonly IApplicationDbContext ctx;
        public RaMateriasRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<ra_mat_materias> Create(ra_mat_materias materia)
        {
            ctx.ra_mat_materias.Add(materia);
            await ctx.SaveChangesAsync();
            return materia;
        }

        public async Task<ra_mat_materias> Get(string id)
        {
            return (await ctx.ra_mat_materias.FindAsync(id))!;
        }

        public async Task<IEnumerable<ra_mat_materias>> GetAll()
        {
            return await ctx.ra_mat_materias.ToListAsync();
        }

        public async Task<IEnumerable<ra_mat_materias>> Search(string searchTerm)
        {
            return await ctx.ra_mat_materias.Where(x=>x.mat_nombre.Contains(searchTerm) || x.mat_codigo.Contains(searchTerm)).ToListAsync();
        }

        public async Task<bool> Update(string id, ra_mat_materias materia)
        {
            ctx.ra_mat_materias.Update(materia);
            return await ctx.SaveChangesAsync() > 0;            
        }

        public async Task<bool> Exists(string id)
        {
            return await ctx.ra_mat_materias.AnyAsync(x=>x.mat_codigo == id);
        }
    }
}