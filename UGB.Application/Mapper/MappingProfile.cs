using AutoMapper;
using UGB.Application.DTO;
using UGB.Domain.Entities;
using UGB.Domain.Wrapper;

namespace UGB.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ra_per_personas, EstudianteDTO>()
            .ForMember(d => d.Id, s => s.MapFrom(e => e.per_codigo))
            .ForMember(d => d.Nombre, s => s.MapFrom(e => e.per_nombres))
            .ForMember(d => d.Apellido, s => s.MapFrom(e => e.per_apellidos))
            .ForMember(d => d.Carrera, s => s.MapFrom(e => e.ra_pla_planes.ra_car_carreras.car_nombre))
            .ForMember(d => d.Plan, s => s.MapFrom(e => e.ra_pla_planes.pla_nombre))
            .ReverseMap();

            CreateMap<users, UserDTO>()
            .ForMember(d=>d.username, s => s.MapFrom(e=>e.username))
            .ReverseMap();

            CreateMap<PagedResult<ra_per_personas>, PagedResult<EstudianteDTO>>().ReverseMap();
        }
    }
}