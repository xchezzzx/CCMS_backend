using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;

namespace ASPNETCore.BuisnessLogic.Managers.CompetitionsManager
{
	public class CompetitionManager : ICompetitionManager
	{
		private readonly IEntityProvider<Competition> _entityProvider;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public CompetitionManager(IEntityProvider<Competition> entityProvider, IExceptionBuilderService exceptionBuilderService)
		{
			_entityProvider = entityProvider;
			_exceptionBuilderService = exceptionBuilderService;
		}

		public Task AddAdministratorToCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public Task AddExerciseToCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public Task AddTeamToCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public async Task CreateNewCompetitionAsync(CompetitionDT competitionDT, int createUserId)
		{
			if (competitionDT == null)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.ArgumentNullException, nameof(competitionDT));
			}
			if (createUserId <= 0)
			{
				throw _exceptionBuilderService.ParseException(ExceptionCodes.ArgumentNullException, nameof(createUserId));
			}

			var competition = ToDBModelsParsers.CompetitionParser(competitionDT);

			try
			{
				await _entityProvider.AddEntityAsync(competition, createUserId);
			}
			catch
			{
				throw;
			}
		}

		public Task DeleteCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public Task DisableCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public Task EndCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public Task GetAllActiveCompetitionsAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<List<CompetitionDT>> GetAllCompetitionsAsync()
		{
			List<Competition> competitions;
			try
			{
				competitions = await _entityProvider.GetAllEntitiesWithIncludeAsync(c => c.CreateUser, c => c.UpdateUser, c => c.Status, c => c.State);
			}
			catch
			{
				throw;
			}

			List<CompetitionDT> result = new List<CompetitionDT>();

			foreach(var competition in competitions)
			{
				result.Add(ToDTModelsParsers.DTCompetitionParser(competition));
			}

			return result;
		}

		public Task GetCompetitionById()
		{
			throw new NotImplementedException();
		}

		public Task RemoveAdministratorFromCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public Task RemoveExerciseFromCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public Task RemoveTeamFromCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public Task StartCompetitionAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateNewCompetitionAsync()
		{
			throw new NotImplementedException();
		}
	}
}
