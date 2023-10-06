using App.Domain.Core.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Contract.Repositories
{
    public interface IUserRepository
    {
        Task<string> Register(RegisterInputDto inputDto);
        Task<string> Login(LoginDto Dto);
    }
}
