
using System.Linq.Expressions;
using ASPNETCore.DataAccess.Models;

namespace ASPNETCore.DataAccess.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : class, ICRUDEntity
    {
        Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);


        Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task AddEntityAsync(TEntity Entity, int userCreateId);

        Task UpdateEntityAsync(TEntity Entity, int userUpdateId);

    }
}
