using Microsoft.EntityFrameworkCore;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Infrastructure.Repositories
{
    public class RouletteRepository : IRouletteRepository
    {
        private readonly SqlContext _context;
        public RouletteRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Roulette>> GetRoulettes()
        {
            var ruletas = await _context.Roulette.ToListAsync();
            return ruletas;
        }

        public async Task<Roulette> GetRouletteById(int id)
        {
            var ruletas = await _context.Roulette.FirstOrDefaultAsync(a => a.id_roulette == id);
            return ruletas;
        }
        public async Task InsertRoulette(Roulette roulette)
        {
            _context.Roulette.Add(roulette);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> OpenRoulette(int id_roulette)
        {
            var ruleta = await _context.Roulette.FirstOrDefaultAsync(a => a.id_roulette == id_roulette);
            ruleta.state = "abierta";
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
        public async Task CloseRoulette(int id_roulette)
        {
            var ruleta = await _context.Roulette.FirstOrDefaultAsync(a => a.id_roulette == id_roulette);
            ruleta.state = "cerrado";
            await _context.SaveChangesAsync();

        }
    }
}
