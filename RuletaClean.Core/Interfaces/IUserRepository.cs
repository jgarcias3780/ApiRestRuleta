using RuletaClean.Core.Entities;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
    }
}
