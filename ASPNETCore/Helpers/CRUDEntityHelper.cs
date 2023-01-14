using ASPNETCore.DataAccess.Models;
using SharedLib.Enums;

namespace ASPNETCore.Helpers
{
    public class CRUDEntityHelper
    {
        public static void CreateEntity<T>(ref T entity, int createUserId) where T : ICRUDEntity
        {
            entity.CreateUserId = createUserId;
            entity.CreateDate = DateTime.Now;
            entity.UpdateUserId = createUserId;
            entity.UpdateDate = DateTime.Now;
            entity.StatusId = (int)EntityStatuses.Active;
        }

        public static void UpdateEntity<T>(ref T entity, int updateUserId) where T : ICRUDEntity
        {
            entity.UpdateUserId = updateUserId;
            entity.UpdateDate = DateTime.Now;
        }

        public static void DeleteEntity<T>(ref T entity, int updateUserId) where T : ICRUDEntity
        {
            entity.UpdateUserId = updateUserId;
            entity.UpdateDate = DateTime.Now;
            entity.StatusId = (int)EntityStatuses.Inactive;
        }
    }
}
