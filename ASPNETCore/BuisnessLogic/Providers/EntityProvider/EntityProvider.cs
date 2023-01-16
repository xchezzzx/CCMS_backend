using ASPNETCore.DataAccess.Models;
using ASPNETCore.Helpers;
using SharedLib.Constants.Enums;
using SharedLib.Services.ExceptionBuilderService;
using System.Linq.Expressions;

namespace ASPNETCore.BuisnessLogic.Providers.EntityProvider
{
	public class EntityProvider<TEntity> : IEntityProvider<TEntity> where TEntity : class, ICRUDEntity
	{
		private readonly DataAccess.Repositories.IEntityRepository<TEntity> _entityRepository;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public EntityProvider(DataAccess.Repositories.IEntityRepository<TEntity> entityRepository, IExceptionBuilderService exceptionBuilderService)
		{
			_entityRepository = entityRepository;
			_exceptionBuilderService = exceptionBuilderService;
		}

		public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			List<TEntity> entities;
			try
			{
				entities = await _entityRepository.GetAllEntitiesWithIncludeAsync(includeProperties);
			}
			catch
			{
				throw;
			}

			return entities;
		}

		public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{

			List<TEntity> entities;
			try
			{
				entities = await _entityRepository.GetAllEntitiesWithIncludeAsync(predicate, includeProperties);
			}
			catch
			{
				throw;
			}

			return entities;
		}

		public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
		{

			List<TEntity> entities;

			try
			{
				entities = await _entityRepository.GetActiveEntitiesWithIncludeAsync(includeProperties);
			}
			catch
			{
				throw;
			}

			return entities;
		}

		public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{

			List<TEntity> entities;
			try
			{
				entities = await _entityRepository.GetActiveEntitiesWithIncludeAsync(predicate, includeProperties);
			}
			catch
			{
				throw;
			}

			return entities;
		}

		public async Task<TEntity> GetEntityByIdWithIncludeAsyncAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
		{

			List<TEntity> entities;

			try
			{
				entities = await _entityRepository.GetActiveEntitiesWithIncludeAsync(e => e.Id == id, includeProperties);
			}
			catch
			{
				throw;
			}
			if (entities.Count == 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNoDataFoundException);
			}
			return entities[0];
		}

		public async Task AddEntityAsync(TEntity Entity, int userCreateId)
		{
			if (Entity == null)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.ArgumentNullException, nameof(Entity));
			}

			if (userCreateId <= 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.ArgumentNullException, nameof(userCreateId));
			}

			CRUDEntityHelper.CreateEntity(ref Entity, userCreateId);

			try
			{
				await _entityRepository.AddEntityAsync(Entity, userCreateId);
			}
			catch
			{
				throw;
			}
		}

		public async Task UpdateEntityAsync(TEntity Entity, int userUpdateId)
		{
			if (Entity == null)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.ArgumentNullException, nameof(Entity));
			}

			if (userUpdateId <= 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.ArgumentNullException, nameof(userUpdateId));
			}

			CRUDEntityHelper.UpdateEntity(ref Entity, userUpdateId);

			try 
			{
			await _entityRepository.UpdateEntityAsync(Entity, userUpdateId);
			}
			catch
			{
				throw;
			}
		}

		public async Task DeleteEntityAsync(TEntity Entity, int userUpdateId)
		{
			if (Entity == null)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.ArgumentNullException, nameof(Entity));
			}

			if (userUpdateId <= 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.ArgumentNullException, nameof(userUpdateId));
			}

			CRUDEntityHelper.DeleteEntity(ref Entity, userUpdateId);

			try 
			{ 
			await _entityRepository.UpdateEntityAsync(Entity, userUpdateId);
			}
			catch
			{
				throw;
			}
		}
	}
}
