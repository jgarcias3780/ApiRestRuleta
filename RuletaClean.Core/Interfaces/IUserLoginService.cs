using RuletaClean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IUserLoginService
    {
        Task<UserLogin> SelectValidUser(UserLogin login);
    }
}
