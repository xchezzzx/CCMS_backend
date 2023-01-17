using ASPNETCore.BuisnessLogic.Providers.CompetitionsToAdministratorsProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.DataAccess.Repositories;
using SharedLib.Services.ExceptionBuilderService;

namespace ASPNETCore.BuisnessLogic.Providers.EntityToCompetitionProvider
{
    public class EntityToCompetitionProvider : IEntityToCompetitionProvider
	{
		private readonly IEntityRepository<User> _userRepository;
		private readonly IEntityRepository<Team> _teamRepository;
		private readonly IEntityRepository<OperatorsToCompetition> _operatorsToCompetitionRepository;
		private readonly IEntityRepository<TeamsToCompetition> _teamsToCompetitionRepository;
		private readonly IEntityRepository<UsersToTeam> _usersToTeamRepository;
		private readonly IEntityRepository<ExercisesToCompetition> _exerciseToCompetitionRepository;
		private readonly IEntityRepository<Exercise> _exerciseRepository;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public EntityToCompetitionProvider(IEntityRepository<Exercise> exerciseRepository, IEntityRepository<ExercisesToCompetition> exerciseToCompetitionRepository, IEntityRepository<UsersToTeam> usersToTeamRepository, IExceptionBuilderService exceptionBuilderService, IEntityRepository<OperatorsToCompetition> operatorsToCompetitionRepository, IEntityRepository<TeamsToCompetition> teamsToCompetitionRepository, IEntityRepository<User> userRepository, IEntityRepository<Team> teamRepository)
		{
			_operatorsToCompetitionRepository = operatorsToCompetitionRepository;
			_teamsToCompetitionRepository = teamsToCompetitionRepository;
			_userRepository = userRepository;
			_teamRepository = teamRepository;
			_exceptionBuilderService = exceptionBuilderService;
			_usersToTeamRepository = usersToTeamRepository;
			_exerciseToCompetitionRepository = exerciseToCompetitionRepository;
			_exerciseRepository = exerciseRepository;
		}


		public async Task<List<User>> GetAllCompetitionOperatorsAsync(int competitionId)
		{
			List<User> users;
			try
			{
				var usersToCompetition = await _operatorsToCompetitionRepository.GetActiveEntitiesWithIncludeAsync(e => e.CompetitionId == competitionId);
				var ids = usersToCompetition.Select(x => x.UserId).ToList();

				users = await _userRepository.GetActiveEntitiesWithIncludeAsync(x => ids.Contains(x.Id), u => u.CreateUser, u => u.UpdateUser);
			}
			catch
			{
				throw;
			}
			return users;
		}

		public async Task<List<Exercise>> GetAllCompetitionExercisesAsync(int competitionId)
		{
			List<Exercise> exercises;
			try
			{
				var exerciseToCompetition = await _exerciseToCompetitionRepository.GetActiveEntitiesWithIncludeAsync(x => x.Id == competitionId);
				var ids = exerciseToCompetition.Select(x => x.Id).ToList();
				exercises = await _exerciseRepository.GetActiveEntitiesWithIncludeAsync(x => ids.Contains(x.Id));
			}
			catch
			{
				throw;
			}
			return exercises;
		}

		public async Task<List<User>> GetAllCompetitionParticipantsAsync(int competitionId)
		{
			List<User> users;
			try
			{
				var teamsToCompetition = await _teamsToCompetitionRepository.GetActiveEntitiesWithIncludeAsync(e => e.CompetitionId == competitionId);
				var teamIds = teamsToCompetition.Select(x => x.TeamId).ToList();

				var usersToTeam = await _usersToTeamRepository.GetActiveEntitiesWithIncludeAsync(x => teamIds.Contains(x.TeamId));
				var userIds = usersToTeam.Select(x => x.UserId);
				
				users = await _userRepository.GetActiveEntitiesWithIncludeAsync(x => userIds.Contains(x.Id), u => u.CreateUser, u => u.UpdateUser);
			}
			catch
			{
				throw;
			}
			return users;
		}

		public async Task<List<Team>> GetAllCompetitionTeamsAsync(int competitionId)
		{
			List<Team> teams;
			try
			{
				var teamsToCompetition = await _teamsToCompetitionRepository.GetActiveEntitiesWithIncludeAsync(e => e.CompetitionId == competitionId);
				var ids = teamsToCompetition.Select(x => x.TeamId).ToList();

				teams = await _teamRepository.GetActiveEntitiesWithIncludeAsync(x => ids.Contains(x.Id), u => u.CreateUser, u => u.UpdateUser);
			}
			catch
			{
				throw;
			}
			return teams;
		}

		public async Task<int> AddOperatorToCompetitionAsync(OperatorsToCompetition usersToCompetition, int userCreateId)
		{
			int id;
			try
			{
				id = (await _operatorsToCompetitionRepository.AddEntityAsync(usersToCompetition, userCreateId)).Id;
			}
			catch
			{
				throw;
			}
			return id;
		}

		public async Task RemoveOperatorFromCompetitionAsync(OperatorsToCompetition usersToCompetition, int userCreateId)
		{
			try
			{
				await _operatorsToCompetitionRepository.UpdateEntityAsync(usersToCompetition, userCreateId);
			}
			catch
			{
				throw;
			}
		}
	}
}
