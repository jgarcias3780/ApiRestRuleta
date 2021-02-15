using AutoMapper;
using RuletaClean.Core.DTOs;
using RuletaClean.Core.Entities;

namespace RuletaClean.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Roulette, RouletteDto>();
            CreateMap<RouletteDto, Roulette>();
            CreateMap<Bet, BetDto>();
            CreateMap<BetDto, Bet>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
