using RuletaClean.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IRuletaRepository
    {
        Task<IEnumerable<Ruleta>> GetRuletas();
        Task InsertRuleta(Ruleta ruleta);
        Task<bool> AbrirRuleta(int id);
        
    }
}
