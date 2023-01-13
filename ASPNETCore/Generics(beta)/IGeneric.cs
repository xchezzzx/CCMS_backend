using ASPNETCore.Models.DBModels;
using System.Data.Entity.Core.Objects.DataClasses;

namespace ASPNETCore.Interfaces
{
    public interface IGeneric<T>  where T : class
    {
        //public List<T> GetAllEntities<T>();
        //public List<T> GetAllEntities<T>(string param);
        public List<T> GetAllEntities(string param1, string param2);
        //public T GetEntitityById<T>();
        //public T GetEntitityById<T>(string param);
        //public T GetEntitityById<T>(string param1, string param2);

        //public Task AddEntity<T>(T entity);

        //public Task UpdateEntity<T>(T entity);

        //public Task DeleteEntity<T>(T entity);
    }
}
