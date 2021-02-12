using RuletaClean.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IApuestaService
    {
        Task InsertApuestas(Apuesta apuesta);

        Task<IEnumerable<Apuesta>> SelectApuestaByRuleta(int id_ruleta);
    }
}