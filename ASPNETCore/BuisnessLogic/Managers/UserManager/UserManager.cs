using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.UserManager
{
    public class UserManager : IUserManager
	{
		private readonly IEntityProvider<User> _userEntityProvider;

		public UserManager(IEntityProvider<User> userEntityProvider)
		{
			_userEntityProvider = userEntityProvider;
		}
		public async Task<UserDT> GetCurrentUserAsync(UserDT userDT)
		{
			try
			{
				var user = (await _userEntityProvider.GetActiveEntitiesWithIncludeAsync(c => c.Password == userDT.Password)).FirstOrDefault();
				userDT = ToDTModelsParsers.DTUserParser(user);
			}
			catch 
			{
				try
				{
                    var user = ToDBModelsParsers.UserParser(userDT);
                    user = await _userEntityProvider.AddNewEntityAsync(user, 1);
                    userDT = ToDTModelsParsers.DTUserParser(user);
                }
				catch 
				{

					throw;
				}

				throw;
			}
			return userDT;
		}

		public async Task<UserDT> AddNewUserAsync(UserDT userDT, int userCreateId)
		{
			try
			{
				var user = ToDBModelsParsers.UserParser(userDT);
				user = await _userEntityProvider.AddNewEntityAsync(user, userCreateId);
				userDT = ToDTModelsParsers.DTUserParser(user);
			}
			catch
			{
				throw;
			}
			return userDT;
		}

        public async Task<List<UserDT>> GetAllUsersAsync()
        {
			List<UserDT> usersDT = new();
			try
			{
				var users = await _userEntityProvider.GetAllEntitiesWithIncludeAsync(c => c.CreateUser, c => c.UpdateUser, c => c.Status);
				foreach (var user in users)
				{
					usersDT.Add(ToDTModelsParsers.DTUserParser(user));
				}
			}
			catch 
			{

				throw;
			}
			return usersDT;
        }

        public async Task<List<UserDT>> GetActiveUsersAsync()
        {
            List<UserDT> usersDT = new();
            try
            {
                var users = await _userEntityProvider.GetActiveEntitiesWithIncludeAsync(c => c.CreateUser, c => c.UpdateUser, c => c.Status);
                foreach (var user in users)
                {
                    usersDT.Add(ToDTModelsParsers.DTUserParser(user));
                }
            }
            catch
            {

                throw;
            }
            return usersDT;
        }

        public async Task UpdateUserAsync(UserDT userDT, int userUpdateId)
        {
            try
            {
				var user = ToDBModelsParsers.UserParser(userDT);
                await _userEntityProvider.UpdateEntityAsync(user, userUpdateId);
            }
            catch
            {

                throw;
            }
        }

        public async Task DeleteUserByIdAsync(int userId, int userUpdateId)
        {

            try
            {
				var user = await _userEntityProvider.GetActiveEntityByIdWithIncludeAsync(userId);
                await _userEntityProvider.DeleteEntityAsync(user, userUpdateId);
            }
            catch
            {

                throw;
            }
        }

        public async Task AssignRoleToUserAsync(int userId, Roles role, int userUpdateId)
        {
            try
            {
                var user = await _userEntityProvider.GetActiveEntityByIdWithIncludeAsync(userId);
                user.RoleId = (int)role;
                await _userEntityProvider.UpdateEntityAsync(user, userUpdateId);
            }
            catch
            {
                throw;
            }
        }
    }
}
