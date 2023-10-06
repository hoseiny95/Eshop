using App.Domain.Core.Users.Dtos;
using App.Domain.Core.Users.Entities;


namespace App.Domain.Core.Users.Contract.Services
{
    public interface IUserServise
    {
        Task<string> Login(LoginDto dto);
        Task<string> Register(RegisterInputDto dto);
        Task<bool> CheckPermissionByRoleId(int id, CancellationToken cancellation, string permission);
    }
}
