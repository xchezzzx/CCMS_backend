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

		public EntityProvider(DataAccess.Repositories.IEntityRepository<TEntity> entityRepository, IExceptionBuilderService exceptionBuilderService)
		{
			_entityRepository = entityRepository;
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

		public async Task<TEntity> GetActiveEntityByIdWithIncludeAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
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
			return entities[0];
		}

		public async Task<TEntity> AddNewEntityAsync(TEntity Entity, int userCreateId)
		{

			CRUDEntityHelper.CreateEntity(ref Entity, userCreateId);

			TEntity addedEntity;
			
			try
			{
				addedEntity = await _entityRepository.AddEntityAsync(Entity, userCreateId);
			}
			catch
			{
				throw;
			}
			return addedEntity;
		}

		public async Task UpdateEntityAsync(TEntity Entity, int userUpdateId)
		{

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
