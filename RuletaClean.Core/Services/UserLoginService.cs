using RuletaClean.Core.Entities;
using RuletaClean.Core.Interfaces;
using System.Threading.Tasks;

namespace RuletaClean.Core.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUnitOfWork _unitOfwork;
        public UserLoginService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public async Task<UserLogin> SelectValidUser(UserLogin login)
        {
            var user = await _unitOfwork.UserLoginRepository.GetValidUser(login);
            return user;
        }
        

    }
}
