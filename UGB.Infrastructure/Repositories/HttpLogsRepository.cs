using UGB.Application.Data;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class HttpLogsRepository : IHttpLogsRepository
    {
        private readonly IApplicationDbContext ctx;
        public HttpLogsRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public void Create(http_logs log)
        {
            ctx.http_logs.Add(log);
            ctx.SaveChanges();
        }

    }
}