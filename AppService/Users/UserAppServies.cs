using App.Domain.Core.Users.Contract.AppServices;
using App.Domain.Core.Users.Contract.Services;
using App.Domain.Core.Users.Dtos;
using App.Domain.Core.Users.Entities;

namespace App.Domain.AppServices.User
{
    public class UserAppService : IUserAppServies
    {
        public readonly IUserServise _userServise;

        public UserAppService(IUserServise userServise)
        {
            _userServise = userServise;
        }

        public async Task<bool> CheckPermissionsByRoleId(int id, CancellationToken cancellation,
                                                    string permission)
        {

            return await _userServise.CheckPermissionByRoleId(id, cancellation, permission);
        }

        public Task<List<Permission>> GetPermissionsByRoleId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(LoginDto dto)
        {
            return await _userServise.Login(dto);
        }

        public async Task<string> Register(RegisterInputDto dto)
        {
            return await _userServise.Register(dto);
        }
    }
}
