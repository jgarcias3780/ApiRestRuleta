using Microsoft.EntityFrameworkCore;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlContext _context;
        public UsuarioRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task<Usuario> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.id_usuario == id);
            return usuario;
        }
    }
}
