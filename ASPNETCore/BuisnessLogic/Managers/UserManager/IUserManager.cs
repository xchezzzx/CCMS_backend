using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.UserManager
{
	public interface IUserManager
	{
		Task<UserDT> GetCurrentUserAsync(UserDT userDT);
		Task<UserDT> AddNewUserAsync(UserDT userDT, int userCreateId);

		Task<List<UserDT>> GetAllUsersAsync();
		Task<List<UserDT>> GetActiveUsersAsync();
		Task UpdateUserAsync(UserDT userDT, int userUpdateId);
        Task DeleteUserByIdAsync(int userId, int userUpdateId);

        Task AssignRoleToUserAsync(int userId, Roles role, int userUpdateId);
    }
}
