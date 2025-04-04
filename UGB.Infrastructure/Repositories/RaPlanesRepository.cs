using UGB.Domain.Entities;
using UGB.Domain.Interfaces;
using UGB.Infrastructure.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class RaPlanesRepository : IRaPlanesRepository
    {
        private readonly IApplicationDbContext ctx;
        public RaPlanesRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<ra_pla_planes> Create(ra_pla_planes plan)
        {
            throw new NotImplementedException();
        }

        public async Task<ra_pla_planes> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ra_pla_planes>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ra_pla_planes>> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(int id, ra_pla_planes plan)
        {
            throw new NotImplementedException();
        }

    }
}