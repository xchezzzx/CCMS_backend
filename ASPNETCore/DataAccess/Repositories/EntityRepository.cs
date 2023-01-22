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
        private readonly ILogger<TEntity> _logger;

		public EntityRepository(Models.DBModels.CCMSContext dbContext, IExceptionBuilderService exceptionBuilderService, ILogger<TEntity> logger)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            _exceptionBuilderService = exceptionBuilderService;
            _logger = logger;
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = await Include(includeProperties).ToListAsync();
            if (entities == null || entities.Count == 0)
            {
                throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, entities.GetType());
            }
            _logger.LogInformation("Get entities {0}", entities.GetType());
            return entities;
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
			var entities = await query.Where(predicate).ToListAsync(); 
			if (entities == null || entities.Count == 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, entities.GetType());
			}

            _logger.LogInformation("Get entities {0}", entities.GetType());
            return entities;
        }

        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.Active);

			var entities = await query.ToListAsync();

			if (entities == null || entities.Count == 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, entities.GetType());
			}

            _logger.LogInformation("Get entities {0}", entities.GetType());
            return entities;
		}


        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties).Where(x => x.StatusId == (int)EntityStatuses.Active).Where(predicate);

			var entities = await query.ToListAsync();

			if (entities == null || entities.Count == 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNullResponseException, entities.GetType());
            }
            _logger.LogInformation("Get entities {0}", entities.GetType());
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

            catch (Exception ex)
            {

                _logger.LogError("Exception has been cathed {0}", ex.Message);
                throw _exceptionBuilderService.ParseException(ExceptionCodes.DBUpdateException, Entity.GetType());
            }

            _logger.LogInformation("New entity has been added {0}: \n id:{1}\n by user:{2} (id)", Entity.GetType(), Entity.Id, userCreateId);
            return addedEntity;
        }

        public async Task UpdateEntityAsync(TEntity Entity, int userUpdateId)
        {
           

			try
			{
				_dbSet.Update(Entity);
				await _dbContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{

                _logger.LogError("Exception has been cathed {0}", ex.Message);
                throw _exceptionBuilderService.ParseException(ExceptionCodes.DBUpdateException, Entity.GetType());
			}
            _logger.LogInformation("Entity has been updated {0}: \n id:{1}\n by user:{2} (id)", Entity.GetType(), Entity.Id, userUpdateId);
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

    }
}
