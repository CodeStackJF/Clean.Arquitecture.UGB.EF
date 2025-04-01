using UGB.Domain.Entities;

namespace UGB.Domain.Interfaces
{
    public interface IRaInscripcionRepository
    {
         Task<ra_ins_inscripcion> Get(int id);
         Task<ra_ins_inscripcion> Create(ra_ins_inscripcion ciclo);
         Task<bool> Update(int id, ra_ins_inscripcion ciclo);
         Task<IEnumerable<ra_ins_inscripcion>> GetAllByEstudiante(int codper);
         Task<IEnumerable<ra_ins_inscripcion>> GetAllByCicloEstudiante(int codcil, int codper);
    }
}