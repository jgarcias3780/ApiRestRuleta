using Microsoft.EntityFrameworkCore;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
using System.Threading.Tasks;

namespace RuletaClean.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlContext _context;
        public UserRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.id_user == id);
            return user;
        }
    }
}
