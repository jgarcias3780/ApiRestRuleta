using Microsoft.EntityFrameworkCore;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaClean.Infrastructure.Repositories
{
    public class RuletaRepository : IRuletaRepository
    {
        private readonly SqlContext _context;
        public RuletaRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ruleta>> GetRuletas()
        {
            var ruletas = await _context.Ruleta.ToListAsync();
            return ruletas;
        }

        public async Task<Ruleta> GetRuletaById(int id)
        {
            var ruletas = await _context.Ruleta.FirstOrDefaultAsync(a => a.id_ruleta == id);
            return ruletas;
        }
        public async Task InsertRuleta(Ruleta ruleta)
        {
            _context.Ruleta.Add(ruleta);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> AbrirRuleta(int id)
        {
            var ruleta = await GetRuletaById(id);
            ruleta.estado = "abierta";
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
        

    }
}
