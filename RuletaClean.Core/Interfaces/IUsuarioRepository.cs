using RuletaClean.Core.Entities;
using System.Threading.Tasks;

namespace RuletaClean.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioById(int id);
    }
}
