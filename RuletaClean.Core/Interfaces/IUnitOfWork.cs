using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRuletaRepository RuletaRepository { get; }
        IApuestaRepository ApuestaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
