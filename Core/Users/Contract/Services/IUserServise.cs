using App.Domain.Core.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Contract.Services
{
    public interface IUserServise
    {
        Task<string> Login(LoginDto dto);
        Task<string> Register(RegisterInputDto dto);
    }
}
