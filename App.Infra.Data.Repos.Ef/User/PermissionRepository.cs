using App.Domain.Core.Users.Contract.Repositories;
using App.Domain.Core.Users.Entities;
using App.Infra.Data.SqlServer.Ef.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.User
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        private readonly IQueryable<Permission> _queryable;
        public PermissionRepository(Maktab97ShopDbContext dbContext) : base(dbContext)
        {
        }


    }

}
