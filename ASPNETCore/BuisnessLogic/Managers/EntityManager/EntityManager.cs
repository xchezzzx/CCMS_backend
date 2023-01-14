using ASPNETCore.DataAccess.Models;

namespace ASPNETCore.BuisnessLogic.Managers.EntityManager
{
    public class EntityManager<TEntity> : IEntityManager<TEntity> where TEntity : class, ICRUDEntity
    {
        public Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetEntityByIdWithIncludeAsyncAsync(int id, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task AddEntityAsync(TEntity Entity, int userCreateId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntityAsync(TEntity Entity, int userUpdateId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntityAsync(TEntity Entity, int userUpdateId)
        {
            throw new NotImplementedException();
        }

    }
}
