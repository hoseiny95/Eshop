using App.Domain.Core.Users.Contract.Repositories;
using App.Domain.Core.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Contract.Manager
{
    public class AppUserManager : UserManager<ApplicationUser>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppUserManager(IUserStore<ApplicationUser> store, 
                              IOptions<IdentityOptions> optionsAccessor, 
                              IPasswordHasher<ApplicationUser> passwordHasher, 
                              IEnumerable<IUserValidator<ApplicationUser>> userValidators, 
                              IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, 
                              ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
                              IServiceProvider services, 
                              ILogger<UserManager<ApplicationUser>> logger,
                              IUnitOfWork unitOfWork) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
             _unitOfWork = unitOfWork;
        }
       

        public async Task<List<Role>> GetRolesAsync(int userId)
        {
           // _unitOfWork.RoleRepository.
            throw new Exception();
        }
    }
}
