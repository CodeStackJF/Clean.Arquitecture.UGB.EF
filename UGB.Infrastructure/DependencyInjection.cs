using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UGB.Application.Data;
using UGB.Domain.Interfaces;
using UGB.Domain.Primitives;
using UGB.Infrastructure.Repositories;

namespace UGB.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistance(configuration);
            return services;
        }

        private static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CleanArquitectureCTX")));
            services.AddScoped<IApplicationDbContext>(x=>x.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IRaCarrerasRepository, RaCarrerasRepository>();
            services.AddScoped<IRaCicloRepository, RaCicloRepository>();
            services.AddScoped<IRaHorariosRepository, RaHorariosRepository>();
            services.AddScoped<IRaInscripcionRepository, RaInscripcionRepository>();
            services.AddScoped<IRaMateriasRepository, RaMateriasRepository>();
            services.AddScoped<IRaPersonasRepository, RaPersonasRepository>();
            services.AddScoped<IRaPlanesMateriasRepository, RaPlanesMateriasRepository>();
            services.AddScoped<IRaPlanesRepository, RaPlanesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IHttpLogsRepository, HttpLogsRepository>();
            services.AddScoped<ISignalRSessionsRepository, SignalRSessionsRepository>();
            return services;
        }
    }
}