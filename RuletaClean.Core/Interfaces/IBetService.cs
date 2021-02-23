using RuletaClean.Core.CustomEntities;
using RuletaClean.Core.Entities;
using RuletaClean.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IBetService
    {
        Task InsertBet(Bet bet);

        Task<IEnumerable<Bet>> SelectBetByRoulette(int id_roulette);

        Task<PagedList<Bet>> SelectBets(BetQueryFilter filters);
    }
}