using ASPNETCore.Constants;
using ASPNETCore.Helpers;
using ASPNETCore.Interfaces.Common;
using ASPNETCore.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace ASPNETCore.Repositories
{ 
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, ICRUDEntity, IEntityWithId
    {
        private readonly CCMSContext _dbContext;
		private readonly DbSet<TEntity> _dbSet;

        public Repository(CCMSContext dbContext)
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
			var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.active);
			return await query.ToListAsync();
		}


		public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.active).Where(predicate);
			return await query.ToListAsync();
		}

		public async Task<TEntity> GetEntityByIdWithIncludeAsyncAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return await Include(includeProperties).Where(e => e.Id == id).FirstOrDefaultAsync();
		}

		public async Task AddEntityAsync(TEntity Entity, int userCreateId)
		{
			FillEntityHelper.CreateEntity(ref Entity, userCreateId);
			await _dbSet.AddAsync(Entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateEntityAsync(TEntity Entity, int userUpdateId)
		{
			FillEntityHelper.UpdateEntity(ref Entity, userUpdateId);
			_dbSet.Update(Entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteEntityAsync(TEntity Entity, int userUpdateId)
		{
			FillEntityHelper.DeleteEntity(ref Entity, userUpdateId);
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
