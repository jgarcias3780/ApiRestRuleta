using RuletaClean.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IBetService
    {
        Task InsertBet(Bet bet);

        Task<IEnumerable<Bet>> SelectBetByRoulette(int id_roulette);
    }
}