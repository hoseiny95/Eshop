using App.Domain.Core.Users.Contract.Repositories;
using App.Domain.Core.Users.Contract.Services;
using App.Domain.Core.Users.Dtos;
using App.Domain.Core.Users.Entities;
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
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<string> Login(LoginDto dto)
        {
           return await _userRepository.Login(dto);
        }

        public async Task<string> Register(RegisterInputDto dto)
        {
            return await _userRepository.Register(dto);
        }

        public async Task<bool> CheckPermissionByRoleId(int id, 
                                                    CancellationToken cancellation,
                                                    string permission)
        {
            var permissions = await _roleRepository.GetPermissionsByRoleId(id, cancellation);

            if (permissions.Any(i => i.Name == permission))
                return true;

            return false;
        }

        
    }
}
