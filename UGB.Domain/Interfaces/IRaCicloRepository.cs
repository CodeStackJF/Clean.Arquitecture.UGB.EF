using UGB.Domain.Entities;

namespace UGB.Domain.Interfaces
{
    public interface IRaCicloRepository
    {
         Task<IEnumerable<ra_cil_ciclo>> GetAll();
         Task<ra_cil_ciclo> Get(int id);
         Task<ra_cil_ciclo?> GetActive();
    }
}