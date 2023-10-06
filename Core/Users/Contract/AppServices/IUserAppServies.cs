using App.Domain.Core.Users.Dtos;
using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Contract.AppServices
{
    public interface IUserAppServies
    {
        Task<string> Login(LoginDto dto);
        Task<string> Register(RegisterInputDto dto);
        Task<List<Permission>> GetPermissionsByRoleId(int id);
    }
}
