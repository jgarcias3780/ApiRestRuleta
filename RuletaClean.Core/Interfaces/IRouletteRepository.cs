using RuletaClean.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IRouletteRepository
    {
        Task<bool> OpenRoulette(int id_roulette);
        Task CloseRoulette(int id_roulette);
        Task<Roulette> GetRouletteById(int id);
        Task<IEnumerable<Roulette>> GetRoulettes();
        Task InsertRoulette(Roulette roulette);
    }
}