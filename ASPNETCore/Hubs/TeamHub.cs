using ASPNETCore.BuisnessLogic.Managers.TeamsManager;
using Microsoft.AspNetCore.SignalR;
using SharedLib.DataTransferModels;

namespace ASPNETCore.Hubs
{
	public class TeamHub : Hub
	{
		private readonly ITeamManager _teamManager;

		public TeamHub(ITeamManager teamManager)
		{
			_teamManager = teamManager;
		}

		public async Task GetAllTeams()
		{
			var teamsDT = await _teamManager.GetAllTeamsAsync();

			await Clients.Caller.SendAsync("GetAllTeams", teamsDT);
		}

		public async Task AddNewTeam(TeamDT teamDT)
		{
			await _teamManager.AddNewTeamAsync(teamDT, 1);

			await Clients.Caller.SendAsync("AddNewTeam", "Success");
		}
	}
}
