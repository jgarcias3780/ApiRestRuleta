using Microsoft.EntityFrameworkCore;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Infrastructure.Repositories
{
    public class ApuestaRepository : IApuestaRepository
    {
        private readonly SqlContext _context;
        public ApuestaRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task InsertApuestas(Apuesta apuesta)
        {
            _context.Apuesta.Add(apuesta);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Apuesta>> SelectApuestaByRuleta(int id_ruleta)
        {
            var apuestas = await _context.Apuesta.Where(p => p.id_ruleta == id_ruleta).ToListAsync();
            return apuestas;
        }
        public async Task<IEnumerable<Apuesta>> SelectGanadorNumero(string numero_ganador, int id_ruleta)
        {
            var ganadores = await _context.Apuesta.Where(p => p.numero == numero_ganador && p.id_ruleta == id_ruleta && p.color == null).ToListAsync();
            return ganadores;
        }

        public async Task<IEnumerable<Apuesta>> SelectGanadorColor(string color_ganador, int id_ruleta)
        {
            var ganadores = await _context.Apuesta.Where(p => p.color == color_ganador && p.id_ruleta == id_ruleta && p.numero == null).ToListAsync();
            return ganadores;
        }
        public async Task UpdateGanador(int id, Apuesta apuesta)
        {
            if (apuesta.id_apuesta == id)
            {
                _context.Entry(apuesta).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

    }
}
