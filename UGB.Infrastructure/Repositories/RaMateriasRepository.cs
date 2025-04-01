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
            throw new NotImplementedException();
        }

        public async Task<ra_mat_materias> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ra_mat_materias>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ra_mat_materias>> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(string id, ra_mat_materias materia)
        {
            throw new NotImplementedException();
        }

    }
}