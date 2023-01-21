using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using SharedLib.DataTransferModels;
using System.Data.Entity.Core.Objects.DataClasses;

namespace ASPNETCore.BuisnessLogic.Managers.UserManager
{
	public class UserManager : IUserManager
	{
		private readonly IEntityProvider<User> _userEntityProvider;

		public UserManager(IEntityProvider<User> userEntityProvider)
		{
			_userEntityProvider = userEntityProvider;
		}
		public async Task<UserDT> GetCurrentUserAsync(string auth0Id)
		{
			UserDT userDT;
			try
			{
				var user = (await _userEntityProvider.GetActiveEntitiesWithIncludeAsync(c => c.Password == auth0Id)).FirstOrDefault();
				userDT = ToDTModelsParsers.DTUserParser(user);
			}
			catch 
			{

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
	}
}
