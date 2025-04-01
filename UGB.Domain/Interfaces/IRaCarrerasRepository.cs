using UGB.Domain.Entities;

namespace UGB.Domain.Interfaces
{
    public interface IRaCarrerasRepository
    {
         Task<IEnumerable<ra_car_carreras>> GetAll();
         Task<ra_car_carreras> Get(int id);
         Task<ra_car_carreras> Create(ra_car_carreras carrera);
         Task<bool> Update(int id, ra_car_carreras carrera);
         Task<IEnumerable<ra_car_carreras>> Search(string searchTerm);
         Task<IEnumerable<ra_car_carreras>> GetAllWithPlanes();    
         Task<ra_car_carreras> GetWithPlanes(int id);
         Task<bool> Exists(int id);
         Task<bool> ExistsName(int id, string name);
         Task Delete(int id);
    }
}