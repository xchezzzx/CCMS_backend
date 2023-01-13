using ASPNETCore.Constants;
using ASPNETCore.Interfaces.Common;

namespace ASPNETCore.Helpers
{
    public class FillEntityHelper
    {
        public static void CreateEntity<T>(ref T entity, int createUserId) where T : IFillable
        {
            entity.CreateUserId = createUserId;
            entity.CreateDate = DateTime.Now;
            entity.UpdateUserId = createUserId;
            entity.UpdateDate = DateTime.Now;
            entity.StatusId = (int)EntityStatuses.active;
        }

        public static void UpdateEntity<T>(ref T entity, int updateUserId) where T : IFillable
        {
            entity.UpdateUserId = updateUserId;
            entity.UpdateDate = DateTime.Now;
        }

        public static void DeleteEntity<T>(ref T entity, int updateUserId) where T : IFillable
        {
            entity.UpdateUserId = updateUserId;
            entity.UpdateDate = DateTime.Now;
            entity.StatusId = (int)EntityStatuses.inactive;
        }
    }
}
