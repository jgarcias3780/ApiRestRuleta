using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
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
        public IRouletteRepository RouletteRepository => new RouletteRepository(_context);

        public IBetRepository BetRepository => new BetRepository(_context);

        public IUserRepository UserRepository => new UserRepository(_context);

        public IUserLoginRepository UserLoginRepository => new UserLoginRepository(_context);

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
