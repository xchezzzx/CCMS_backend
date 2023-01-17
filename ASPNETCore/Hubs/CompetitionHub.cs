using ASPNETCore.BuisnessLogic.Managers.CompetitionsManager;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.Editing;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;
using System.Collections.Generic;

namespace ASPNETCore.Hubs
{
	public class CompetitionHub : Hub
	{

		private readonly ICompetitionManager _competitionManager;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public CompetitionHub(ICompetitionManager competitionManager, IExceptionBuilderService exceptionBuilderService)
		{
			_competitionManager = competitionManager;
			_exceptionBuilderService = exceptionBuilderService;
		}

		public async Task GetAllCompetitions()
		{

			List<CompetitionDT> competitionsDT;
			try
			{
				competitionsDT = await _competitionManager.GetAllCompetitionsAsync();
			}
			catch
			{
				throw;
			}

			await Clients.All.SendAsync("GetAllCompetitions", competitionsDT);
		}

		public async Task GetActiveCompetitions()
		{
			List<CompetitionDT> competitionsDT;
			try
			{
				competitionsDT = await _competitionManager.GetActiveCompetitionsAsync();
			}
			catch
			{
				throw;
			}

			await Clients.Caller.SendAsync("GetActiveCompetitions", competitionsDT);
		}

		public async Task GetCompetitionById(int competitionId)
		{
			CompetitionDT competitionDT;
			try
			{
				competitionDT = await _competitionManager.GetCompetitionByIdAsync(competitionId);
			}
			catch
			{
				throw;
			}

			await Clients.All.SendAsync("GetCompetitionById", competitionDT);
		}

		public async Task AddNewCompetition(CompetitionDT competitionDT)
		{

			CompetitionDT competitonDT;
			string res = "Succes";

			try
			{
				if (competitionDT == null)
				{
					throw _exceptionBuilderService.ParseException(ExceptionCodes.HubMethodNullArgumentException, nameof(competitionDT));
				}

				competitonDT = await _competitionManager.AddNewCompetitionAsync(competitionDT, 1);
			}
			catch
			{
				res = "failed";
			}

			await Clients.Caller.SendAsync("AddNewCompetition", res, competitionDT);
		}

		public async Task DeleteCompetitionById(int competitionId)
		{
			string res = "success";
			try
			{
				await _competitionManager.DeleteCompetitionByIdAsync(competitionId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("DeleteCompetitionById", res);
		}

		public async Task StartCompetitionById(int competitionId)
		{
			string res = "success";
			try
			{
				await _competitionManager.StartCompetitionByIdAsync(competitionId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("StartCompetitionById", res);
		}

		public async Task EndCompetitionById(int competitionId)
		{
			string res = "success";
			try
			{
				await _competitionManager.EndCompetitionByIdAsync(competitionId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("EndCompetitionById", res);
		}


		public async Task UpdateCompetition(CompetitionDT competitionDT)
		{
			string res = "success";
			try
			{
				await _competitionManager.UpdateCompetitionAsync(competitionDT, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("UpdateCompetition", res);
		}

		public async Task AddNewOperatorToCompetition(int competitionId, int operatorId)
		{
			string res = "success";
			try
			{
				await _competitionManager.AddNewOperatorToCompetitionAsync(competitionId, operatorId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("AddNewOperatorToCompetition", res);
		}

		public async Task RemoveOperatorFromCompetition(int competitionId, int operatorId)
		{
			string res = "success";
			try
			{
				await _competitionManager.RemoveOperatorFromCompetitionAsync(competitionId, operatorId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("RemoveOperatorFromCompetition", res);
		}

		public async Task AddNewExerciseToCompetition(int competitionId, int exerciseId)
		{
			string res = "success";
			try
			{
				await _competitionManager.AddNewExerciseToCompetitionAsync(competitionId, exerciseId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("AddNewExerciseToCompetition", res);
		}

		public async Task RemoveExerciseFromCompetition(int competitionId, int exerciseId)
		{
			string res = "success";
			try
			{
				await _competitionManager.RemoveExerciseFromCompetitionAsync(competitionId, exerciseId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("RemoveExerciseFromCompetition", res);
		}

		public async Task AddNewTeamToCompetition(int competitionId, int teamId)
		{
			string res = "success";
			try
			{
				await _competitionManager.AddNewTeamToCompetitionAsync(competitionId, teamId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("AddNewTeamToCompetition", res);
		}

		public async Task RemoveTeamFromCompetition(int competitionId, int teamId)
		{
			string res = "success";
			try
			{
				await _competitionManager.RemoveTeamFromCompetitionAsync(competitionId, teamId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}

			await Clients.Caller.SendAsync("RemoveTeamFromCompetition", res);


		}

		public async Task GetAllCompetitionOperators(int competitionId)
		{
			List<UserDT> usersDT;
			try
			{
				usersDT = await _competitionManager.GetAllCompetitionOperatorsAsync(competitionId);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("GetAllCompetitionOperators", usersDT);
		}

		public async Task GetAllCompetitionParticipants(int competitionId)
		{
			List<UserDT> usersDT;
			try
			{
				usersDT = await _competitionManager.GetAllCompetitionParticipantsAsync(competitionId);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("GetAllCompetitionParticipants", usersDT);
		}

		public async Task GetAllCompetitionExercises(int competitionId)
		{
			List<ExerciseDT> exerciseDT;
			try
			{
				exerciseDT = await _competitionManager.GetAllCompetitionExercisesAsync(competitionId);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("GetAllCompetitionExercises", exerciseDT);
		}

		public async Task GetAllCompetitionTeams(int competitionId)
		{
			List<TeamDT> teamDT;
			try
			{
				teamDT = await _competitionManager.GetAllCompetitionTeamsAsync(competitionId);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("GetAllCompetitionTeams", teamDT);
		}
	}

}