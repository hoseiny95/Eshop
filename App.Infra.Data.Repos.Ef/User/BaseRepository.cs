using App.Domain.Core.Users.Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.User
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        protected BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async virtual Task AddAsync(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
        }

        public async virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async virtual Task<bool> ExistsAsync(Guid id)
        {
            return await DbContext.Set<TEntity>().AnyAsync();
        }

        public async virtual Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async virtual Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbContext.Set<TEntity>().AnyAsync(predicate);
        }

        public virtual void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().UpdateRange(entities);
        }
    }
}
