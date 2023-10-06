using App.Domain.Core.Users.Contract.Repositories;
using App.Domain.Core.Users.Contract.Services;
using App.Domain.Core.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.User
{
    public class UserService : IUserServise
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Login(LoginDto dto)
        {
           return await _userRepository.Login(dto);
        }

        public async Task<string> Register(RegisterInputDto dto)
        {
            return await _userRepository.Register(dto);
        }
    }
}
