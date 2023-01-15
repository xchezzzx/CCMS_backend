using ASPNETCore.DataAccess.Models;
using ASPNETCore.DataAccess.Repositories;
using ASPNETCore.Helpers;
using System.Linq.Expressions;

namespace ASPNETCore.BuisnessLogic.Providers.EntityProvider
{
    public class EntityProvider<TEntity> : IEntityProvider<TEntity> where TEntity : class, ICRUDEntity
    {
        private readonly DataAccess.Repositories.IEntityProvider<TEntity> _entityRepository;

        public EntityProvider(DataAccess.Repositories.IEntityProvider<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _entityRepository.GetAllEntitiesWithIncludeAsync(includeProperties);
        }

        public async Task<List<TEntity>> GetAllEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _entityRepository.GetAllEntitiesWithIncludeAsync(predicate, includeProperties);
        }

        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _entityRepository.GetActiveEntitiesWithIncludeAsync(includeProperties);
        }

        public async Task<List<TEntity>> GetActiveEntitiesWithIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _entityRepository.GetActiveEntitiesWithIncludeAsync(predicate, includeProperties);
        }

        public async Task<TEntity> GetEntityByIdWithIncludeAsyncAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = await _entityRepository.GetActiveEntitiesWithIncludeAsync(e => e.Id == id, includeProperties);
            return entities[0];
        }

        public async Task AddEntityAsync(TEntity Entity, int userCreateId)
        {
            CRUDEntityHelper.CreateEntity(ref Entity, userCreateId);
            await _entityRepository.AddEntityAsync(Entity, userCreateId);
        }

        public async Task UpdateEntityAsync(TEntity Entity, int userUpdateId)
        {
            CRUDEntityHelper.UpdateEntity(ref Entity, userUpdateId);
            await _entityRepository.UpdateEntityAsync(Entity, userUpdateId);
        }

        public async Task DeleteEntityAsync(TEntity Entity, int userUpdateId)
        {
            CRUDEntityHelper.DeleteEntity(ref Entity, userUpdateId);
            await _entityRepository.UpdateEntityAsync(Entity, userUpdateId);
        }
    }
}
