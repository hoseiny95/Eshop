

using App.Domain.Core.Users.Contract.Repositories;
using App.Domain.Core.Users.Entities;
using App.Infra.Data.SqlServer.Ef.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.User;

public class RoleRepository : IRoleRepository
{
    private Maktab97ShopDbContext _context;

    public RoleRepository(Maktab97ShopDbContext context)
    {
        _context = context;
    }
    public async Task<List<Permission>> GetPermissionsByRoleId(int id, CancellationToken cancellation)
    {
        var permissions = await _context.Roles.Where(i => i.Id == id)
                            .Include(i => i.Permissions)
                            .SelectMany(i => i.Permissions).ToListAsync(cancellation);
        return permissions;
    }


}
