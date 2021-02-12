using RuletaClean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IApuestaRepository
    {
        Task InsertApuestas(Apuesta apuesta);
        Task<IEnumerable<Apuesta>> SelectApuestaByRuleta(int id_ruleta);
        Task<IEnumerable<Apuesta>> SelectGanadorNumero(string numero_ganador, int id_ruleta);
        Task<IEnumerable<Apuesta>> SelectGanadorColor(string color_ganador, int id_ruleta);
        Task UpdateGanador(int id, Apuesta apuesta);
    }
}
