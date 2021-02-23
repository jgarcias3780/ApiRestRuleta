using RuletaClean.Core.Entities;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IUserLoginRepository
    {
        Task<UserLogin> GetValidUser(UserLogin login);
    }
}