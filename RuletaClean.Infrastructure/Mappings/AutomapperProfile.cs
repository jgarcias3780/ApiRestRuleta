using AutoMapper;
using RuletaClean.Core.DTOs;
using RuletaClean.Core.Entities;

namespace RuletaClean.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Ruleta, RuletaDto>();
            CreateMap<RuletaDto, Ruleta>();
            CreateMap<Apuesta, ApuestaDto>();
            CreateMap<ApuestaDto, Apuesta>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
