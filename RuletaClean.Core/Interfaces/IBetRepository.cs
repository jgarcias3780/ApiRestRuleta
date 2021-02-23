using RuletaClean.Core.Entities;
using RuletaClean.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IBetRepository
    {
        Task InsertBet(Bet bet);
        Task<IEnumerable<Bet>> SelectBetByRoulette(int id_roulette);
        Task<IEnumerable<Bet>> SelectWinningNumber(string winning_number, int id_roulette);
        Task<IEnumerable<Bet>> SelectWinningColor(string winning_color, int id_roulette);
        Task UpdateWinner(int id, Bet bet);
        Task<IEnumerable<Bet>> SelectBets();
    }
}
