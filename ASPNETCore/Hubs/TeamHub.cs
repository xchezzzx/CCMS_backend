using ASPNETCore.BuisnessLogic.Managers.TeamsManager;
using Microsoft.AspNetCore.SignalR;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;

namespace ASPNETCore.Hubs
{
	public class TeamHub : Hub
	{
		private readonly ITeamManager _teamManager;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public TeamHub(ITeamManager teamManager, IExceptionBuilderService exceptionBuilderService)
		{
			_teamManager = teamManager;
			_exceptionBuilderService = exceptionBuilderService;
		}

		public async Task GetAllTeams()
		{
			List<TeamDT> teamsDT;
			try
			{
				teamsDT = await _teamManager.GetAllTeamsAsync();
			}
			catch
			{
				throw;
			}

			await Clients.Caller.SendAsync("GetAllTeams", teamsDT);
		}

		public async Task AddNewTeam(TeamDT teamDT)
		{
			string res = "Success";
			try
			{
				if (teamDT == null)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamDT));
				}
				await _teamManager.AddNewTeamAsync(teamDT, 1);
			}
			catch
			{
				res = "failed";
			}
			await Clients.Caller.SendAsync("AddNewTeam", res);
		}
	}
}
