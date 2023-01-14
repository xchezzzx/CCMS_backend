using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.TeamsManager
{
	public class TeamManager : ITeamManager
	{
		private readonly IEntityProvider<Team> _entityProvider;

		public TeamManager(IEntityProvider<Team> entityProvider)
		{
			_entityProvider = entityProvider;
		}

		public async Task AddNewTeamAsync(TeamDT teamDT, int userCreateId)
		{
			var team = ToDBModelsParsers.TeamParser(teamDT);
			await _entityProvider.AddEntityAsync(team, userCreateId);
		}

		public async Task<List<TeamDT>> GetAllTeamsAsync()
		{
			var teams = await _entityProvider.GetAllEntitiesWithIncludeAsync(t => t.UpdateUser, t => t.CreateUser, t => t.Status);
			var result = new List<TeamDT>();
			foreach (var team in teams)
			{
				result.Add(ToDTModelsParsers.DTTeamParser(team));
			}
			return result;
		}
	}
}
