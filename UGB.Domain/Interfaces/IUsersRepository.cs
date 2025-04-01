using UGB.Domain.Entities;

namespace UGB.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<users> Create(users user);
        Task<users> Get(string username);
        Task<bool> Exists(string username);
    }
}