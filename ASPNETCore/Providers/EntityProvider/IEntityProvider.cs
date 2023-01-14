using ASPNETCore.Interfaces.Common;
using System.Linq.Expressions;

namespace ASPNETCore.Providers.EntityProvider
{
	public interface IEntityProvider<TEntity> where TEntity : class, ICRUDEntity
	{
		Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);
		Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);


		Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);
		Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);


		Task<TEntity> GetEntityByIdWithIncludeAsyncAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties);

		Task AddEntityAsync(TEntity Entity, int userCreateId);

		Task UpdateEntityAsync(TEntity Entity, int userUpdateId);

		Task DeleteEntityAsync(TEntity Entity, int userUpdateId);
	}
}
