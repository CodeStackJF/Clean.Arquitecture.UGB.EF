using UGB.Domain.Entities;

namespace UGB.Domain.Interfaces
{
    public interface IRaMateriasRepository
    {
         Task<IEnumerable<ra_mat_materias>> GetAll();
         Task<ra_mat_materias> Get(string id);
         Task<ra_mat_materias> Create(ra_mat_materias materia);
         Task<bool> Update(string id, ra_mat_materias materia);
         Task<IEnumerable<ra_mat_materias>> Search(string searchTerm);
    }
}