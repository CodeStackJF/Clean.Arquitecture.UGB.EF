using UGB.Domain.Entities;

namespace UGB.Domain.Interfaces
{
    public interface IRaHorariosRepository
    {
         Task<IEnumerable<ra_hor_horarios>> GetAll();
         Task<ra_hor_horarios> Get(int id);
         Task<ra_hor_horarios> Create(ra_hor_horarios ciclo);
         Task<bool> Update(int id, ra_hor_horarios ciclo);
         Task<IEnumerable<ra_hor_horarios>> GetAllByPlanMateria(int codcil, int codpla, string codmat);
         Task<bool> ExistsHorario(int codhor, int codcil, int codpla, string codmat, string grupo);
    }
}