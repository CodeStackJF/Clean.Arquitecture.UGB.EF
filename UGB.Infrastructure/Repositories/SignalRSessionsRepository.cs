using Microsoft.EntityFrameworkCore;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;
using UGB.Infrastructure.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class SignalRSessionsRepository : ISignalRSessionsRepository
    {
        private readonly IApplicationDbContext ctx;
        public SignalRSessionsRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }
        
        public async Task Insert(string username, bool connected, string connection_id)
        {
            signal_r_sessions session = new Domain.Entities.signal_r_sessions(){
                    username = username,
                    connected = connected,
                    connection_date = DateTime.Now,
                    connection_id = connection_id
                };
            if(await ctx.signal_r_sessions.AnyAsync(x=>x.username == username))
            {
                ctx.signal_r_sessions.Update(session);
            }
            else
            {
                ctx.signal_r_sessions.Add(session);
            }
            await ctx.SaveChangesAsync();
        }
    }
}