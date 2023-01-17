using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;

namespace ASPNETCore.BuisnessLogic.Managers.TeamsManager
{
    public class TeamManager : ITeamManager
	{
		private readonly IEntityProvider<Team> _entityProvider;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public TeamManager(IEntityProvider<Team> entityProvider, IExceptionBuilderService exceptionBuilderService)
		{
			_entityProvider = entityProvider;
			_exceptionBuilderService = exceptionBuilderService;
		}

		public async Task AddNewTeamAsync(TeamDT teamDT, int userCreateId)
		{
			if (teamDT == null)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.ArgumentNullException, nameof(teamDT));
			}

			var team = ToDBModelsParsers.TeamParser(teamDT);
			try
			{
				await _entityProvider.AddNewEntityAsync(team, userCreateId);
			}
			catch
			{
				throw;
			}
		}

		public async Task<List<TeamDT>> GetAllTeamsAsync()
		{
			List<Team> teams;
			try
			{
				teams = await _entityProvider.GetAllEntitiesWithIncludeAsync(t => t.UpdateUser, t => t.CreateUser, t => t.Status);
			}
			catch
			{
				throw;
			}
			
			var result = new List<TeamDT>();
			foreach (var team in teams)
			{
				result.Add(ToDTModelsParsers.DTTeamParser(team));
			}
			return result;
		}
	}
}
