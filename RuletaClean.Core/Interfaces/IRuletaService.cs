using RuletaClean.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IRuletaService
    {
        Task<bool> AbrirRuleta(int id_ruleta);
        Task<IEnumerable<Ruleta>> GetRuletas();
        Task InsertRuleta(Ruleta ruleta);
    }
}