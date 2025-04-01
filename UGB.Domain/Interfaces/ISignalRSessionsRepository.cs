namespace UGB.Domain.Interfaces
{
    public interface ISignalRSessionsRepository
    {
        Task Insert(string username, bool connected, string connection_id);
    }
}