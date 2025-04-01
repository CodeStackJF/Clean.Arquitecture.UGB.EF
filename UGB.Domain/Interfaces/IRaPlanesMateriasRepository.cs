using UGB.Domain.Entities;

namespace UGB.Domain.Interfaces
{
    public interface IRaPlanesMateriasRepository
    {
         Task<IEnumerable<ra_plm_planes_materias>> GetAll();
         Task<ra_plm_planes_materias> Get(int codpla, string codmat);
         Task<ra_plm_planes_materias> Create(ra_plm_planes_materias plan);
         Task<bool> Update(int codpla, string codmat, ra_plm_planes_materias plan);
         Task<IEnumerable<ra_plm_planes_materias>> Search(string searchTerm);
         Task<IEnumerable<ra_plm_planes_materias>> GetByPlan(int codpla);
    }
}