using RuletaClean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IApuestaRepository
    {
        Task<string> InsertApuestas(Apuesta apuesta);
        
        Task<IEnumerable<Apuesta>> SelectApuestaByRuleta(int id_ruleta);

    }
}
