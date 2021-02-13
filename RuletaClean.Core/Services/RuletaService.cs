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
        private readonly IRuletaRepository _ruletaRepository;
        public RuletaService(IRuletaRepository ruletaRepository)
        {
            _ruletaRepository = ruletaRepository;
        }
        public async Task<IEnumerable<Ruleta>> GetRuletas()
        {
            var ruletas = await _ruletaRepository.GetRuletas();
            return ruletas;
        }
        public async Task InsertRuleta(Ruleta ruleta)
        {
            await _ruletaRepository.InsertRuleta(ruleta);
        }
        public async Task<bool> AbrirRuleta(int id_ruleta)
        {
            return await _ruletaRepository.AbrirRuleta(id_ruleta);
        }
    }
}
