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
        private readonly Models.DBModels.CCMSContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public EntityRepository(Models.DBModels.CCMSContext dbContext, IExceptionBuilderService exceptionBuilderService)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            _exceptionBuilderService = exceptionBuilderService;
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = await Include(includeProperties).ToListAsync();
            if (entities == null || entities.Count == 0)
            {
                throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, nameof(entities));
            }
            return entities;
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
			var entities = await query.Where(predicate).ToListAsync(); 
			if (entities == null || entities.Count == 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, nameof(entities));
			}
			return entities;
        }

        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.Active);

			var entities = await query.ToListAsync();

			if (entities == null || entities.Count == 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, nameof(entities));
			}
			return entities;
		}


        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.Active).Where(predicate);

			var entities = await query.ToListAsync();

			if (entities == null || entities.Count == 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, nameof(entities));
			}
			return entities;
		}

        public async Task<TEntity> AddEntityAsync(TEntity Entity, int userCreateId)
		{
			TEntity addedEntity;

			try
			{
				addedEntity = (await _dbSet.AddAsync(Entity)).Entity;
                if (addedEntity == null)
                {
                    throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException);
                }
				await _dbContext.SaveChangesAsync();
			}
            catch
            {
                throw _exceptionBuilderService.ParseException(ExceptionCodes.DBUpdateException, nameof(Entity));
            }
            return addedEntity;
        }

        public async Task UpdateEntityAsync(TEntity Entity, int userUpdateId)
        {
           

			try
			{
				_dbSet.Update(Entity);
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
