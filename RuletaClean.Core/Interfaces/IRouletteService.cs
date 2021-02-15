using RuletaClean.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IRouletteService
    {
        Task<bool> OpenRoulette(int id_roulette);
        Task<IEnumerable<Roulette>> GetRoulettes();
        Task InsertRoulette(Roulette roulette);
    }
}