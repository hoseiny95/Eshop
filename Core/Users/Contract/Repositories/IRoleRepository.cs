using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Contract.Repositories;

public interface IRoleRepository
{
    Task<List<Permission>> GetPermissionsByRoleId(int id, CancellationToken cancellation);
    Task<List<Role>> GetRolesByUserId(int userId);
}
