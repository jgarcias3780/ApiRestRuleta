using Microsoft.EntityFrameworkCore;
using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using RuletaClean.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Infrastructure.Repositories
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly SqlContext _context;
        public UserLoginRepository(SqlContext context)
        {
            _context = context;
        }
        public async Task<UserLogin> GetValidUser(UserLogin login)
        {
            var user = await _context.Userapi.FirstOrDefaultAsync(a => a.user_name == login.user_name && a.password_name == login.password_name);
            return user;
        }
    }
}
