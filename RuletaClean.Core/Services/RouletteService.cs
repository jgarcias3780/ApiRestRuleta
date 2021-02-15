using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly IUnitOfWork unitOfwork;
        public RouletteService(IUnitOfWork _unitOfwork)
        {
            unitOfwork = _unitOfwork;
        }
        public async Task<IEnumerable<Roulette>> GetRoulettes()
        {
            var ruletas = await unitOfwork.RouletteRepository.GetRoulettes();
            return ruletas;
        }
        public async Task InsertRoulette(Roulette roulette)
        {
            await unitOfwork.RouletteRepository.InsertRoulette(roulette);
        }
        public async Task<bool> OpenRoulette(int id_roulette)
        {
            return await unitOfwork.RouletteRepository.OpenRoulette(id_roulette);
        }
    }
}
