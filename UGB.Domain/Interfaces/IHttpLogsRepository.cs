using UGB.Domain.Entities;

namespace UGB.Domain.Interfaces
{
    public interface IHttpLogsRepository
    {
        void Create(http_logs log);
    }
}