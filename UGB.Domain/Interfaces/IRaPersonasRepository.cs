using UGB.Domain.Entities;
using UGB.Domain.Wrapper;

namespace UGB.Domain.Interfaces
{
    public interface IRaPersonasRepository
    {
         Task<IEnumerable<ra_per_personas>> GetAll(string searchTerm);
         Task<PagedResult<ra_per_personas>> GetAllPaged(int currentPage, string searchTerm);
         Task<ra_per_personas> Get(int id);
         Task<ra_per_personas> Create(ra_per_personas estudiante);
         Task<bool> Update(int id, ra_per_personas estudiante);
         Task<IEnumerable<ra_per_personas>> Search(string searchTerm);
         Task<bool> ExistsCarnet(int id, string carnet);
         Task<ra_per_personas> GetWithNestedData(int id);
    }
}