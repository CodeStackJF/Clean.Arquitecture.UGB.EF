using Microsoft.EntityFrameworkCore;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;
using UGB.Infrastructure.Interfaces;

namespace UGB.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IApplicationDbContext ctx;
        public UsersRepository(IApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<users> Create(users user)
        {
            ctx.users.Add(user);
            await ctx.SaveChangesAsync();
            return user;
        }

        public async Task<users> Get(string username)
        {
            return (await ctx.users.Where(x=>x.username == username).FirstOrDefaultAsync())!;
        }

        public async Task<bool> Exists(string username)
        {
            return await ctx.users.AnyAsync(x=>x.username == username);
        }

    }
}