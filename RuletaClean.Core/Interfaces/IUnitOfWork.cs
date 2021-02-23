using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRouletteRepository RouletteRepository { get; }
        IBetRepository BetRepository { get; }
        IUserRepository UserRepository { get; }
        IUserLoginRepository UserLoginRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
