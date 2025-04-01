using UGB.Domain.Entities;

namespace UGB.Domain.Interfaces
{
    public interface IRaPlanesRepository
    {
         Task<IEnumerable<ra_pla_planes>> GetAll();
         Task<ra_pla_planes> Get(string id);
         Task<ra_pla_planes> Create(ra_pla_planes plan);
         Task<bool> Update(int id, ra_pla_planes plan);
         Task<IEnumerable<ra_pla_planes>> Search(string searchTerm);
    }
}