using ASPNETCore.BuisnessLogic.Managers.TeamsManager;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
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

		public async Task GetActiveTeams()
		{
			List<TeamDT> teamsDT;
			try
			{
				teamsDT = await _teamManager.GetActiveTeamsAsync();
			}
			catch
			{
				throw;
			}

			await Clients.Caller.SendAsync("GetActiveTeams", teamsDT);
		}

		public async Task GetTeamByIdAsync(int teamId)
		{
			TeamDT teamDT;
			try
			{
				teamDT = await _teamManager.GetTeamByIdAsync(teamId);
			}
			catch
			{
				throw;
			}

			await Clients.Caller.SendAsync("GetTeamByIdAsync", teamDT);
		}

		public async Task AddNewTeam(TeamDT teamDT)
		{
			try
			{
				if (teamDT == null)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamDT));
				}
				teamDT = await _teamManager.AddNewTeamAsync(teamDT, 1);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("AddNewTeam", teamDT);
		}

		public async Task UpdateTeam(TeamDT teamDT)
		{
			try
			{
				if (teamDT == null)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamDT));
				}
				await _teamManager.UpdateTeamAsync(teamDT, 1);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("UpdateTeam", teamDT);
		}

		public async Task DeleteTeamByIdASync(int teamId)
		{
			string res = "succes";
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				await _teamManager.DeleteTeamByIdASync(teamId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}
			await Clients.Caller.SendAsync("DeleteTeamByIdASync", res);
		}

		public async Task GetAllTeamMembers(int teamId)
		{
			List<UserDT> usersDT;
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				usersDT = await _teamManager.GetAllTeamMembersAsync(teamId);
			}
			catch 
			{ 
				throw; 
			}
			await Clients.Caller.SendAsync("GetAllTeamMembers", usersDT);
		}


		public async Task GetAllTeamCompetitions(int teamId)
		{
			List<CompetitionDT> competitionsDT;
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				competitionsDT = await _teamManager.GetAllTeamCompetitionsAsync(teamId);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("GetAllTeamCompetitions", competitionsDT);
		}


		public async Task GetTeamCurrentOrNearestCompetition(int teamId)
		{
			CompetitionDT competitionDT;
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				competitionDT = await _teamManager.GetTeamCurrentOrNearestCompetitionAsync(teamId);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("GetTeamCurrentOrNearestCompetition", competitionDT);
		}

		public async Task GetAllCompetitionTeamExercises(int teamId)
		{
			List<ExerciseDT> exercisesDT;
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				exercisesDT = await _teamManager.GetAllCompetitionTeamExercisesAsync(teamId, 1);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("GetAllCompetitionTeamExercises", exercisesDT);
		}

		public async Task AddNewTeamMember(int teamId, int userId)
		{
			string res = "succes";
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				if (userId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(userId));
				}
				await _teamManager.AddNewTeamMemberAsync(teamId, userId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}
			await Clients.Caller.SendAsync("AddNewTeamMember", res);
		}


        public async Task AddNewTeamMembers(int teamId, List<int> userIds)
        {
            string res = "succes";
            try
            {
                if (teamId <= 0)
                {
                    throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
                }
                if (userIds.Count == 0)
                {
                    throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(userIds));
                }
				foreach (var id in userIds)
                {
                    await _teamManager.AddNewTeamMemberAsync(teamId, id, 1);
                }
            }
            catch
            {
                res = "failed";
                throw;
            }
            await Clients.Caller.SendAsync("AddNewTeamMember", res);
        }

        public async Task RemoveMemberFromTeam(int teamId, int userId)
		{
			string res = "succes";
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				if (userId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(userId));
				}
				await _teamManager.RemoveMemberFromTeamAsync(teamId, userId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}
			await Clients.Caller.SendAsync("RemoveMemberFromTeam", res);
		}

		public async Task AddNewExerciseToCompetitionTeam(int teamId, int userId, int competitionId)
		{
			string res = "succes";
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				if (userId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(userId));
				}
				if (competitionId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(competitionId));
				}
				await _teamManager.AddNewExerciseToCompetitionTeamAsync(teamId, userId, competitionId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}
			await Clients.Caller.SendAsync("AddNewExerciseToCompetitionTeam", res);
		}

		public async Task RemoveExerciseFromCompetitionTeam(int teamId, int userId, int competitionId)
		{
			string res = "succes";
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				if (userId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(userId));
				}
				if (competitionId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(competitionId));
				}
				await _teamManager.RemoveExerciseFromCompetitionTeamAsync(teamId, userId, competitionId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}
			await Clients.Caller.SendAsync("RemoveExerciseFromCompetitionTeam", res);
		}


		public async Task MakeTeamMemberCaptain(int teamId, int userId)
		{
			string res = "succes";
			try
			{
				if (teamId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(teamId));
				}
				if (userId <= 0)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(userId));
				}
				await _teamManager.MakeTeamMemberCaptainAsync(teamId, userId, 1);
			}
			catch
			{
				res = "failed";
				throw;
			}
			await Clients.Caller.SendAsync("MakeTeamMemberCaptain", res);
		}

		public async Task UpdateExerciseToCompetitionTeam(ExerciseToTeamToCompetitionDT exercisesToTeamToCompetitionDT, int userUpdateId)
		{

			try
			{
				await _teamManager.UpdateExerciseToCompetitionTeamAsync(exercisesToTeamToCompetitionDT, userUpdateId);
			}
			catch
			{
				throw;
			}
		}
	}

	
}
