using ASPNETCore.DataAccess.Models;
using ASPNETCore.DataAccess.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using SharedLib.Constants.Enums;
using SharedLib.Services.ExceptionBuilderService;
using System.Linq.Expressions;

namespace ASPNETCore.DataAccess.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, ICRUDEntity
    {
        private readonly CCMSContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public EntityRepository(CCMSContext dbContext, IExceptionBuilderService exceptionBuilderService)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            _exceptionBuilderService = exceptionBuilderService;
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = await Include(includeProperties).ToListAsync();
            if (entities == null)
            {
                throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, nameof(entities));
            }
            return entities;
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
			var entities = await query.Where(predicate).ToListAsync(); 
			if (entities == null)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, nameof(entities));
			}
			return entities;
        }

        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.Active);

			var entities = await query.ToListAsync();

			if (entities == null)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, nameof(entities));
			}
			return entities;
		}


        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.Active).Where(predicate);

			var entities = await query.ToListAsync();

			if (entities == null)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, nameof(entities));
			}
			return entities;
		}

        public async Task AddEntityAsync(TEntity Entity, int userCreateId)
        {
            await _dbSet.AddAsync(Entity);
            try
            {
				await _dbContext.SaveChangesAsync();
			}
            catch
            {
                throw _exceptionBuilderService.ParseException(ExceptionCodes.DBUpdateException, nameof(Entity));
            }
        }

        public async Task UpdateEntityAsync(TEntity Entity, int userUpdateId)
        {
            _dbSet.Update(Entity);

			try
			{
				await _dbContext.SaveChangesAsync();
			}
			catch
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBUpdateException, nameof(Entity));
			}
		}

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

    }
}
