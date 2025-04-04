using Microsoft.Extensions.DependencyInjection;
using UGB.Application.Validations;
using FluentValidation;
using System.Reflection;
using UGB.Application.Mapper;
namespace UGB.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddPersistance();
            return services;
        }

        private static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RaCarrerasValidation>();
            services.AddValidatorsFromAssemblyContaining<RaCicloValidation>();
            services.AddValidatorsFromAssemblyContaining<RaHorariosValidation>();
            services.AddValidatorsFromAssemblyContaining<RaInscripcionValidation>();
            services.AddValidatorsFromAssemblyContaining<RaMateriasValidation>();
            services.AddValidatorsFromAssemblyContaining<RaPersonasValidation>();
            services.AddValidatorsFromAssemblyContaining<RaPlanesMateriasValidation>();
            services.AddValidatorsFromAssemblyContaining<RaPlanesValidation>();
            services.AddValidatorsFromAssemblyContaining<UsersValidation>();
            services.AddValidatorsFromAssemblyContaining<EmailValidation>();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            return services;
        }
    }
}