using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _context;
        public UnitOfWork(SqlContext context)
        {
            _context = context;
        }
        public IRuletaRepository RuletaRepository => new RuletaRepository(_context);

        public IApuestaRepository ApuestaRepository => new ApuestaRepository(_context);

        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(_context);

        public void Dispose()
        {
            if(_context!= null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
