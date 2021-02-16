using Microsoft.EntityFrameworkCore;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaClean.Infrastructure.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly SqlContext _context;
        public BetRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task InsertBet(Bet bet)
        {
            _context.Bet.Add(bet);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Bet>> SelectBetByRoulette(int id_roulette)
        {
            var bets = await _context.Bet.Where(p => p.id_roulette == id_roulette).ToListAsync();
            return bets;
        }
        public async Task<IEnumerable<Bet>> SelectWinningNumber(string winning_number, int id_roulette)
        {
            var winners = await _context.Bet.Where(p => p.number == winning_number && p.id_roulette == id_roulette && p.color == null).ToListAsync();
            return winners;
        }

        public async Task<IEnumerable<Bet>> SelectWinningColor(string winning_color, int id_roulette)
        {
            var winners = await _context.Bet.Where(p => p.color == winning_color && p.id_roulette == id_roulette && p.number == null).ToListAsync();
            return winners;
        }
        public async Task UpdateWinner(int id, Bet bet)
        {
            if (bet.id_bet == id)
            {
                _context.Entry(bet).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
