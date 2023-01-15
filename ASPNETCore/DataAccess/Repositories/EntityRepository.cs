﻿using ASPNETCore.DataAccess.Models;
using ASPNETCore.DataAccess.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using SharedLib.Enums;
using System.Linq.Expressions;

namespace ASPNETCore.DataAccess.Repositories
{
    public class EntityRepository<TEntity> : IEntityProvider<TEntity> where TEntity : class, ICRUDEntity
    {
        private readonly CCMSContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public EntityRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return await query.Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.Active);
            return await query.ToListAsync();
        }


        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.Active).Where(predicate);
            return await query.ToListAsync();
        }

        public async Task AddEntityAsync(TEntity Entity, int userCreateId)
        {
            await _dbSet.AddAsync(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync(TEntity Entity, int userUpdateId)
        {
            _dbSet.Update(Entity);
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

    }
}
