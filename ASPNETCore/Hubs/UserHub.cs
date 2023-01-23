using ASPNETCore.BuisnessLogic.Managers.UserManager;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.Editing;
using SharedLib.Constants.Enums;
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

		public async Task GetCurrentUser(UserDT userDT)
		{
			try
			{
				userDT = await _userManager.GetCurrentUserAsync(userDT);

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

        public async Task GetAllUsers()
		{
			List<UserDT> usersDT = new();
			try
			{
				usersDT = await _userManager.GetAllUsersAsync();
				await Clients.Caller.SendAsync("GetAllUsers", usersDT);
			}
			catch 
			{

				throw;
			}
		}

        public async Task GetAllActiveUsers()
		{
            List<UserDT> usersDT = new();
            try
            {
                usersDT = await _userManager.GetActiveUsersAsync();
                await Clients.Caller.SendAsync("GetAllActiveUsers", usersDT);
            }
            catch
            {

                throw;
            }
        }

        public async Task UpdateUser(UserDT userDT, int userUpdateId)
		{
            try
            {
                await _userManager.UpdateUserAsync(userDT, userUpdateId);
            }
            catch
            {

                throw;
            }
        }

        public async Task DeleteUserById(int userId, int userUpdateId)
		{

            try
            {
                await _userManager.DeleteUserByIdAsync(userId, userUpdateId);
            }
            catch
            {

                throw;
            }
        }

        public async Task AssignRoleToUser(int userId, Roles role, int userUpdateId)
		{

            try
            {
                await _userManager.AssignRoleToUserAsync(userId, role, userUpdateId);
            }
            catch
            {

                throw;
            }
        }




		public async Task GetOperatorCurrentOrNearestCompetition(int operatorId)
		{
			CompetitionDT competitionDT = new();
			try
			{
				competitionDT = await _userManager.GetOperatorCurrentOrNearestCompetitionAsync(operatorId);
				await Clients.Caller.SendAsync("GetOperatorCurrentOrNearestCompetition", competitionDT);
			}
			catch 
			{
				throw;
			}
		}

		public async Task GetParticipantCurrentOrNearestCompetition(int participantId)
		{

			CompetitionDT competitionDT = new();
			try
			{
				competitionDT = await _userManager.GetParticipantCurrentOrNearestCompetitionAsync(participantId);
				await Clients.Caller.SendAsync("GetParticipantCurrentOrNearestCompetition", competitionDT);
			}
			catch
			{
				throw;
			}
		}

		public async Task GetFiveCurrentOrNearestCompetitions()
		{

			List<CompetitionDT> competitionsDT = new();
			try
			{
				competitionsDT = await _userManager.GetFiveCurrentOrNearestCompetitionsAsync();
				await Clients.Caller.SendAsync("GetFiveCurrentOrNearestCompetitions", competitionsDT);
			}
			catch
			{
				throw;
			}
		}

		public async Task GetParticipantTeam(int participantId)
		{
			TeamDT teamDT = new();
			try
			{
				teamDT = await _userManager.GetParticipantTeamAsync(participantId);
				await Clients.Caller.SendAsync("GetParticipantTeam", teamDT);
			}
			catch
			{
				throw;
			}
		}
	}
}
