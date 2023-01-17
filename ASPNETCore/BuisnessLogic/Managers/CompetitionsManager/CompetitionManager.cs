using ASPNETCore.BuisnessLogic.Providers.CompetitionsToAdministratorsProvider;
using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using Microsoft.CodeAnalysis.Editing;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;
using System.Collections.Generic;

namespace ASPNETCore.BuisnessLogic.Managers.CompetitionsManager
{
    public class CompetitionManager : ICompetitionManager
	{
		private readonly IEntityProvider<Competition> _competitionEntityProvider;
		private readonly IEntityProvider<OperatorsToCompetition> _operatorsToCompetitionEntityProvider;
		private readonly IEntityProvider<TeamsToCompetition> _teamsToCompetitionEntityProvider;
		private readonly IEntityProvider<ExercisesToCompetition> _exercisesToCompetitionEntityProvider;
		private readonly IEntityToCompetitionProvider _entityToCompetitionProvider;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public CompetitionManager(IEntityProvider<ExercisesToCompetition> exercisesToCompetitionEntityProvider, IEntityProvider<TeamsToCompetition> teamsToCompetitionEntityProvider, IEntityProvider<OperatorsToCompetition> operatorsToCompetitionEntityProvider, IEntityProvider<Competition> entityProvider, IExceptionBuilderService exceptionBuilderService, IEntityToCompetitionProvider entityToCompetitionProvider)
		{
			_competitionEntityProvider = entityProvider;
			_exceptionBuilderService = exceptionBuilderService;
			_entityToCompetitionProvider = entityToCompetitionProvider;
			_operatorsToCompetitionEntityProvider = operatorsToCompetitionEntityProvider;
			_teamsToCompetitionEntityProvider = teamsToCompetitionEntityProvider;
			_exercisesToCompetitionEntityProvider = exercisesToCompetitionEntityProvider;
		}

		public async Task<List<CompetitionDT>> GetAllCompetitionsAsync()
		{
			List<Competition> competitions;
			try
			{
				competitions = await _competitionEntityProvider.GetAllEntitiesWithIncludeAsync(c => c.CreateUser, c => c.UpdateUser, c => c.Status, c => c.State);
			}
			catch
			{
				throw;
			}

			List<CompetitionDT> result = new List<CompetitionDT>();

			foreach (var competition in competitions)
			{
				result.Add(ToDTModelsParsers.DTCompetitionParser(competition));
			}

			return result;
		}

		public async Task<List<CompetitionDT>> GetActiveCompetitionsAsync()
		{
			List<Competition> competitions;
			try
			{
				competitions = await _competitionEntityProvider.GetActiveEntitiesWithIncludeAsync(c => c.CreateUser, c => c.UpdateUser, c => c.Status, c => c.State);
			}
			catch
			{
				throw;
			}

			List<CompetitionDT> result = new List<CompetitionDT>();

			foreach (var competition in competitions)
			{
				result.Add(ToDTModelsParsers.DTCompetitionParser(competition));
			}

			return result;
		}

		public async Task<CompetitionDT> AddNewCompetitionAsync(CompetitionDT competitionDT, int createUserId)
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
				competition = await _competitionEntityProvider.AddNewEntityAsync(competition, createUserId);
			}
			catch
			{
				throw;
			}

			competitionDT = ToDTModelsParsers.DTCompetitionParser(competition);

			return competitionDT;
		}

		public async Task<CompetitionDT> GetCompetitionByIdAsync(int competitionId)
		{
			CompetitionDT competitionDT;
			try
			{
				var competition = await _competitionEntityProvider.GetEntityByIdWithIncludeAsync(competitionId, c => c.Status, c => c.CreateUser, c => c.UpdateUser, c => c.State);
				competitionDT = ToDTModelsParsers.DTCompetitionParser(competition);
			}
			catch
			{
				throw;
			}
			return competitionDT;
		}

		public async Task DeleteCompetitionByIdAsync(int competitionId, int updateUserId)
		{
			try
			{
				var competition = await _competitionEntityProvider.GetEntityByIdWithIncludeAsync(competitionId);

				await _competitionEntityProvider.DeleteEntityAsync(competition, updateUserId);
			}
			catch
			{
				throw;
			}
		}

		public async Task DisableCompetitionByIdAsync(int competitionId, int updateUserId)
		{
			try
			{
				var competition = await _competitionEntityProvider.GetEntityByIdWithIncludeAsync(competitionId);

				competition.StateId = (int)CompetitionStates.Canceled;

				await _competitionEntityProvider.UpdateEntityAsync(competition, updateUserId);
			}
			catch
			{
				throw;
			}
		}

		public async Task StartCompetitionByIdAsync(int competitionId, int updateUserId)
		{
			try
			{
				var competition = await _competitionEntityProvider.GetEntityByIdWithIncludeAsync(competitionId);

				competition.StateId = (int)CompetitionStates.InProgress;
				competition.StartDateTime = DateTime.Now;
				competition.EndDateTime = competition.StartDateTime + competition.Duration;

				await _competitionEntityProvider.UpdateEntityAsync(competition, updateUserId);
			}
			catch
			{
				throw;
			}
		}

		public async Task EndCompetitionByIdAsync(int competitionId, int updateUserId)
		{
			try
			{
				var competition = await _competitionEntityProvider.GetEntityByIdWithIncludeAsync(competitionId);

				competition.StateId = (int)CompetitionStates.Ended;
				competition.EndDateTime = DateTime.Now;
				competition.Duration = competition.StartDateTime - competition.EndDateTime;

				await _competitionEntityProvider.UpdateEntityAsync(competition, updateUserId);
			}
			catch
			{
				throw;
			}
		}

		public async Task UpdateCompetitionAsync(CompetitionDT competitionDT, int updateUserId)
		{
			var competition = ToDBModelsParsers.CompetitionParser(competitionDT);

			await _competitionEntityProvider.UpdateEntityAsync(competition, updateUserId);
		}



		public async Task AddNewOperatorToCompetitionAsync(int competitionId, int operatorId, int createUserId)
		{
			try
			{
				var operatorToCompetition = new OperatorsToCompetition()
				{
					CompetitionId = competitionId,
					UserId = operatorId,
				};
				await _operatorsToCompetitionEntityProvider.AddNewEntityAsync(operatorToCompetition, createUserId);
			}
			catch
			{
				throw;
			}
		}

		public async Task RemoveOperatorFromCompetitionAsync(int competitionId, int operatorId, int updateUserId)
		{
			try
			{
				var operatorToCompetition = new OperatorsToCompetition()
				{
					CompetitionId = competitionId,
					UserId = operatorId,
				};
				await _operatorsToCompetitionEntityProvider.DeleteEntityAsync(operatorToCompetition, updateUserId);
			}
			catch
			{

				throw;
			}
		}



		public async Task AddNewExerciseToCompetitionAsync(int competitionId, int exerciseId, int createUserId)
		{

			try
			{
				var exercisesToCompetition = new ExercisesToCompetition()
				{
					CompetitionId = competitionId,
					ExerciseId = exerciseId,
				};
				await _exercisesToCompetitionEntityProvider.AddNewEntityAsync(exercisesToCompetition, createUserId);
			}
			catch
			{
				throw;
			}
		}

		public async Task RemoveExerciseFromCompetitionAsync(int competitionId, int exerciseId, int updateUserId)
		{
			try
			{
				var exercisesToCompetition = new ExercisesToCompetition()
				{
					CompetitionId = competitionId,
					ExerciseId = exerciseId,
				};
				await _exercisesToCompetitionEntityProvider.DeleteEntityAsync(exercisesToCompetition, updateUserId);
			}
			catch
			{
				throw;
			}
		}



		public async Task AddNewTeamToCompetitionAsync(int competitionId, int teamId, int createUserId)
		{
			try
			{
				var teamsToCompetition = new TeamsToCompetition()
				{
					CompetitionId = competitionId,
					TeamId = teamId,
				};
				await _teamsToCompetitionEntityProvider.AddNewEntityAsync(teamsToCompetition, createUserId);
			}
			catch
			{
				throw;
			}
		}

		public async Task RemoveTeamFromCompetitionAsync(int competitionId, int teamId, int updateUserId)
		{
			try
			{
				var teamsToCompetition = new TeamsToCompetition()
				{
					CompetitionId = competitionId,
					TeamId = teamId,
				};
				await _teamsToCompetitionEntityProvider.DeleteEntityAsync(teamsToCompetition, updateUserId);
			}
			catch
			{
				throw;
			}
		}



		public async Task<List<UserDT>> GetAllCompetitionOperatorsAsync(int competitionId)
		{
			List<UserDT> usersDT = new();
			try
			{
				var users = await _entityToCompetitionProvider.GetAllCompetitionOperatorsAsync(competitionId);
				foreach (var user in users)
				{
					usersDT.Add(ToDTModelsParsers.DTUserParser(user));
				}
			}
			catch
			{
				throw;
			}
			return usersDT;
		}

		public async Task<List<UserDT>> GetAllCompetitionParticipantsAsync(int competitionId)
		{
			List<UserDT> usersDT = new();
			try
			{
				var users = await _entityToCompetitionProvider.GetAllCompetitionParticipantsAsync(competitionId);
				foreach (var user in users)
				{
					usersDT.Add(ToDTModelsParsers.DTUserParser(user));
				}
			}
			catch
			{
				throw;
			}
			return usersDT;
		}

		public async Task<List<ExerciseDT>> GetAllCompetitionExercisesAsync(int competitionId)
		{
			List<ExerciseDT> exercisesDT = new();
			try
			{
				var exercises = await _entityToCompetitionProvider.GetAllCompetitionExercisesAsync(competitionId);
				foreach (var exercise in exercises)
				{
					exercisesDT.Add(ToDTModelsParsers.DTExerciseParser(exercise));
				}
			}
			catch
			{
				throw;
			}
			return exercisesDT;
		}

		public async Task<List<TeamDT>> GetAllCompetitionTeamsAsync(int competitionId)
		{
			List<TeamDT> teamsDT = new();
			try
			{
				var teams = await _entityToCompetitionProvider.GetAllCompetitionTeamsAsync(competitionId);
				foreach (var team in teams)
				{
					teamsDT.Add(ToDTModelsParsers.DTTeamParser(team));
				}
			}
			catch
			{
				throw;
			}
			return teamsDT;
		}


		/////////////////////////////////////////////////////////////



	}
}
