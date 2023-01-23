using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.DataAccess.Repositories;
using SharedLib.Constants.Enums;

namespace ASPNETCore.BuisnessLogic.Providers.EntityToTeamProvider
{
    public class EntityToTeamProvider : IEntityToTeamProvider
	{
		private readonly IEntityRepository<ExercisesToTeamToCompetition> _exercisesToTeamToCompetitionRepository;
		private readonly IEntityRepository<UsersToTeam> _usersToTeamRepository;
		private readonly IEntityRepository<TeamsToCompetition> _teamsToCompetitionRepository;
		private readonly IEntityRepository<User> _userRepository;
		private readonly IEntityRepository<Competition> _competitionRepository;
		private readonly IEntityRepository<Exercise> _exerciseRepository;

		public EntityToTeamProvider(IEntityRepository<Competition> competitionRepository, IEntityRepository<TeamsToCompetition> teamsToCompetitionRepository, IEntityRepository<Exercise> exerciseRepository, IEntityRepository<ExercisesToTeamToCompetition> exercisesToTeamToCompetitionRepository, IEntityRepository<UsersToTeam> usersToTeamRepository, IEntityRepository<User> userRepository)
		{
			_exercisesToTeamToCompetitionRepository = exercisesToTeamToCompetitionRepository;
			_usersToTeamRepository = usersToTeamRepository;
			_userRepository = userRepository;
			_exerciseRepository = exerciseRepository;
			_teamsToCompetitionRepository = teamsToCompetitionRepository;
			_competitionRepository = competitionRepository;
		}

		public async Task<List<Exercise>> GetAllCompetitionTeamExercisesAsync(int competitionId, int teamId)
		{
			List<Exercise> exercises;
			try
			{
				var exercisesToTeamToCompetition = await _exercisesToTeamToCompetitionRepository
					.GetActiveEntitiesWithIncludeAsync(x => x.CompetitionId == competitionId && x.TeamId == teamId);

				var ids = exercisesToTeamToCompetition.Select(x => x.CompetitionId).ToList();

				exercises = await _exerciseRepository
					.GetActiveEntitiesWithIncludeAsync(x => ids.Contains(x.Id), x => x.CreateUser, x => x.UpdateUser, x => x.Status, x => x.Category, x => x.Platform, x => x.Lang);
			}
			catch 
			{
				throw;
			}

			return exercises;
		}

		public async Task<List<Competition>> GetAllTeamCompetitionsAsync(int teamId)
		{
			List<Competition> competitions;
			try
			{
				var teamsToCompetitions = await _teamsToCompetitionRepository.GetActiveEntitiesWithIncludeAsync(x => x.TeamId == teamId);
				var ids = teamsToCompetitions.Select(x => x.CompetitionId).ToList();
				competitions = await _competitionRepository.GetActiveEntitiesWithIncludeAsync(x => ids.Contains(x.Id));
			}
			catch
			{

				throw;
			}

			return competitions;
		}

		public async Task<List<User>> GetAllTeamMembersAsync(int teamId)
		{

			List<User> users;
			try
			{
				var usersToTeam = await _usersToTeamRepository.GetActiveEntitiesWithIncludeAsync(x => x.TeamId == teamId);
				var ids = usersToTeam.Select(x => x.UserId).ToList();
				users = await _userRepository.GetActiveEntitiesWithIncludeAsync(x => ids.Contains(x.Id));
			}
			catch
			{

				throw;
			}

			return users;
		}

		public async Task<Competition> GetTeamCurrentOrNearestCompetitionAsync(int teamId)
		{
			Competition competition;

			try
			{
				var competitionIds = (await _teamsToCompetitionRepository.GetActiveEntitiesWithIncludeAsync(x => x.TeamId == teamId)).Select(x => x.CompetitionId).ToList();
				try
				{
					competition = (await _competitionRepository.GetActiveEntitiesWithIncludeAsync(x => competitionIds.Contains(x.Id) && x.StateId == (int)CompetitionStates.InProgress)).FirstOrDefault();
				}
				catch 
				{
					competition = (await _competitionRepository.GetActiveEntitiesWithIncludeAsync(x => competitionIds.Contains(x.Id) && x.StateId == (int)CompetitionStates.InProgress)).OrderBy(x => x.StartDateTime).ToList()[0];
				}
			}
			catch
			{
				throw;
			}
			return competition;
		}
	}
}
