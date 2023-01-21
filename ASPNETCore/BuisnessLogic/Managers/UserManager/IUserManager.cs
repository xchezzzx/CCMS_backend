using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.UserManager
{
	public interface IUserManager
	{
		Task<UserDT> GetCurrentUserAsync(string auth0Id);
		Task<UserDT> AddNewUserAsync(UserDT userDT, int userCreateId);
	}
}
