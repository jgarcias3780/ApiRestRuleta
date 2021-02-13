﻿using RuletaClean.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IRuletaRepository
    {
        Task<bool> AbrirRuleta(int id_ruleta);
        Task CerrarRuleta(int id_ruleta);
        Task<Ruleta> GetRuletaById(int id);
        Task<IEnumerable<Ruleta>> GetRuletas();
        Task InsertRuleta(Ruleta ruleta);
    }
}