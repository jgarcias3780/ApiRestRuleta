using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Core.Services
{
    public class RuletaService : IRuletaService
    {
        private readonly IUnitOfWork unitOfwork;
        public RuletaService(IUnitOfWork _unitOfwork)
        {
            unitOfwork = _unitOfwork;
        }
        public async Task<IEnumerable<Ruleta>> GetRuletas()
        {
            var ruletas = await unitOfwork.RuletaRepository.GetRuletas();
            return ruletas;
        }
        public async Task InsertRuleta(Ruleta ruleta)
        {
            await unitOfwork.RuletaRepository.InsertRuleta(ruleta);
        }
        public async Task<bool> AbrirRuleta(int id_ruleta)
        {
            return await unitOfwork.RuletaRepository.AbrirRuleta(id_ruleta);
        }
    }
}
