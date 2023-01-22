using ASPNETCore.BuisnessLogic.Managers.UserManager;
using Microsoft.AspNetCore.SignalR;
using SharedLib.DataTransferModels;

namespace ASPNETCore.Hubs
{
	public class UserHub : Hub
	{
		private readonly IUserManager _userManager;

		public UserHub(IUserManager userManager)
		{
			_userManager = userManager;
		}

		public async Task GetCurrentUser(string auth0Id)
		{
			try
			{
				var userDT = await _userManager.GetCurrentUserAsync(auth0Id);

				await Clients.Caller.SendAsync("GetCurrentUser", userDT);
			}
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}

		public async Task AddNewUser(UserDT userDT)
		{
			try
			{
				userDT = await _userManager.AddNewUserAsync(userDT, 1);
				await Clients.Caller.SendAsync("AddNewUser", userDT);
			}
			catch
			{
				throw;
			}
		}
	}
}
