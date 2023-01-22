using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.BuisnessLogic.Providers.EntityToTeamProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;

namespace ASPNETCore.BuisnessLogic.Managers.TeamsManager
{
    public class TeamManager : ITeamManager
	{
		private readonly IEntityProvider<Team> _teamEntityProvider;
		private readonly IEntityProvider<ExercisesToTeamToCompetition> _exercisesToTeamToCompetitionEntityProvider;
		private readonly IEntityToTeamProvider _entityToTeamProvider;
		private readonly IEntityProvider<Exercise> _exerciseEntityProvider;
		private readonly IEntityProvider<UsersToTeam> _usersToTeamEntityProvider;

		public TeamManager(IEntityProvider<UsersToTeam> usersToTeamEntityProvider, IEntityProvider<ExercisesToTeamToCompetition> exercisesToTeamToCompetitionEntityProvider, IEntityProvider<Exercise> exerciseEntityProvider, IEntityToTeamProvider entityToTeamProvider, IEntityProvider<Team> entityProvider)
		{
			_teamEntityProvider = entityProvider;
			_entityToTeamProvider = entityToTeamProvider;
			_exerciseEntityProvider = exerciseEntityProvider;
			_exercisesToTeamToCompetitionEntityProvider = exercisesToTeamToCompetitionEntityProvider;
			_usersToTeamEntityProvider = usersToTeamEntityProvider;
		}


		public async Task<List<TeamDT>> GetAllTeamsAsync()
		{
			List<Team> teams;
			try
			{
				teams = await _teamEntityProvider.GetAllEntitiesWithIncludeAsync(t => t.UpdateUser, t => t.CreateUser, t => t.Status);
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

		public async Task<List<TeamDT>> GetActiveTeamsAsync()
		{
			List<Team> teams;
			try
			{
				teams = await _teamEntityProvider.GetActiveEntitiesWithIncludeAsync(t => t.UpdateUser, t => t.CreateUser, t => t.Status);
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

		public async Task<TeamDT> GetTeamByIdAsync(int teamId)
		{
			Team team;
			try
			{
				team = await _teamEntityProvider.GetActiveEntityByIdWithIncludeAsync(teamId, t => t.UpdateUser, t => t.CreateUser, t => t.Status);
			}
			catch
			{
				throw;
			}

			var result = ToDTModelsParsers.DTTeamParser(team);
			return result;
		}

		public async Task<TeamDT> AddNewTeamAsync(TeamDT teamDT, int userCreateId)
		{

			var team = ToDBModelsParsers.TeamParser(teamDT);
			try
			{
				team = await _teamEntityProvider.AddNewEntityAsync(team, userCreateId);
				teamDT = ToDTModelsParsers.DTTeamParser(team);
			}
			catch
			{
				throw;
			}
			return teamDT;
		}

		public async Task UpdateTeamAsync(TeamDT teamDT, int userUpdateId)
		{
			try
			{
				var team = ToDBModelsParsers.TeamParser(teamDT);
				await _teamEntityProvider.UpdateEntityAsync(team, userUpdateId);
			}
			catch
			{
				throw;
			}
		}

		public async Task DeleteTeamByIdASync(int teamId, int userUpdateId)
		{
			try
			{
				var team = await _teamEntityProvider.GetActiveEntityByIdWithIncludeAsync(teamId);
				await _teamEntityProvider.DeleteEntityAsync(team, userUpdateId);
			}
			catch
			{
				throw;
			}
		}



		public async Task<List<UserDT>> GetAllTeamMembersAsync(int teamId)
		{
			List<UserDT> usersDT = new();
			try
			{
				var users = await _entityToTeamProvider.GetAllTeamMembersAsync(teamId);
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

		public async Task<List<CompetitionDT>> GetAllTeamCompetitionsAsync(int teamId)
		{
			List<CompetitionDT> competitionDT = new();
			try
			{
				var competitions = await _entityToTeamProvider.GetAllTeamCompetitionsAsync(teamId);
				foreach (var competition in competitions)
				{
					competitionDT.Add(ToDTModelsParsers.DTCompetitionParser(competition));
				}
			}
			catch
			{

				throw;
			}
			return competitionDT;
		}

		public async Task<CompetitionDT> GetTeamCurrentOrNearestCompetitionAsync(int teamId)
		{
			CompetitionDT competitionDT;
			try
			{
				var competition = await _entityToTeamProvider.GetTeamCurrentOrNearestCompetitionAsync(teamId);
				competitionDT = ToDTModelsParsers.DTCompetitionParser(competition);
			}
			catch
			{
				throw;
			}
			return competitionDT;
		}


		public async Task<List<ExerciseDT>> GetAllCompetitionTeamExercisesAsync(int competitionId, int teamId)
		{
			List<ExerciseDT> exerciseDT = new();
			try
			{
				var exercises = await _entityToTeamProvider.GetAllCompetitionTeamExercisesAsync(competitionId, teamId);
				foreach (var exercise in exercises)
				{
					exerciseDT.Add(ToDTModelsParsers.DTExerciseParser(exercise));
				}
			}
			catch
			{

				throw;
			}
			return exerciseDT;
		}


		public async Task AddNewExerciseToCompetitionTeamAsync(int competitionId, int teamId, int exerciseId, int userCreateId)
		{
			ExercisesToTeamToCompetition exerciseToTeamToCompetition;

			try
			{
				var exercise = (await _exerciseEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.Id == exerciseId))[0];

					exerciseToTeamToCompetition = new()
					{
						CompetitionId = competitionId,
						TeamId = teamId,
						ExerciseId = exerciseId,
						ApprovedPoints = null,
						TakeTime = DateTime.Now,
						SubmitTime = null,
						Timeframe = (TimeSpan)(exercise.Timeframe + exercise?.BonusTimeframe),
						SubmitDuration = null,
						ExerciseStateId = (int)ExerciseStates.Taken,
						SolutionLink = String.Empty,
						Comment = String.Empty,
						FileLink = String.Empty
					};

					await _exercisesToTeamToCompetitionEntityProvider.AddNewEntityAsync(exerciseToTeamToCompetition, userCreateId);

			}
			catch
			{
				throw;
			}
		}



		public async Task UpdateExerciseToCompetitionTeamAsync(ExerciseToTeamToCompetitionDT exercisesToTeamToCompetitionDT, int userUpdateId)
		{

			try
			{

				var exerciseToTeamToCompetition = ToDBModelsParsers.ExerciseToTeamToCompetitionParser(exercisesToTeamToCompetitionDT);
				await _exercisesToTeamToCompetitionEntityProvider.UpdateEntityAsync(exerciseToTeamToCompetition, userUpdateId);

			}
			catch
			{
				throw;
			}
		}


		public async Task AddNewTeamMemberAsync(int teamId, int userId, int userCreateId)
		{
			try
			{
				var usersToTeam = new UsersToTeam()
				{
					TeamId = teamId,
					UserId = userId,
					IsCaptain = false
				};

				await _usersToTeamEntityProvider.AddNewEntityAsync(usersToTeam, userCreateId);
			}
			catch
			{

				throw;
			}
		}


		public async Task MakeTeamMemberCaptainAsync(int teamId, int userId, int userUpdateId)
		{
			try
			{
				var usersToTeam = await _usersToTeamEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.TeamId == teamId);

					for (int i = 0; i < usersToTeam.Count; i++)
					{
						if (usersToTeam[i].IsCaptain && usersToTeam[i].Id != userId)
						{
							usersToTeam[i].IsCaptain = false;
							await _usersToTeamEntityProvider.UpdateEntityAsync(usersToTeam[i], userUpdateId);
						}
						if (usersToTeam[i].Id == userId && !usersToTeam[i].IsCaptain)
						{
							usersToTeam[i].IsCaptain = true;
							await _usersToTeamEntityProvider.UpdateEntityAsync(usersToTeam[i], userUpdateId);
						}
					}
			}
			catch 
			{
				throw;
			}
		}

		public async Task RemoveExerciseFromCompetitionTeamAsync(int competitionId, int teamId, int exerciseId, int userUpdateId)
		{
			try
			{
				var exerciseToTeamToCompetition = (await _exercisesToTeamToCompetitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.CompetitionId == competitionId && x.TeamId == teamId && x.ExerciseId == exerciseId))[0];
				await _exercisesToTeamToCompetitionEntityProvider.DeleteEntityAsync(exerciseToTeamToCompetition, userUpdateId);
			}
			catch 
			{
				throw;
			}
		}

		public async Task RemoveMemberFromTeamAsync(int teamId, int userId, int userUpdateId)
		{
			try
			{
				var userToTeam = (await _usersToTeamEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.TeamId == teamId && x.UserId == userId))[0];
				await _usersToTeamEntityProvider.DeleteEntityAsync(userToTeam, userUpdateId);
			}
			catch 
			{
				throw;
			}
		}
	}
}
