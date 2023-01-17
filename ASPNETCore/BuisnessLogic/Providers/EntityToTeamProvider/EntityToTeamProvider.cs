using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.DataAccess.Repositories;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;

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
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public EntityToTeamProvider(IExceptionBuilderService exceptionBuilderService, IEntityRepository<Competition> competitionRepository, IEntityRepository<TeamsToCompetition> teamsToCompetitionRepository, IEntityRepository<Exercise> exerciseRepository, IEntityRepository<ExercisesToTeamToCompetition> exercisesToTeamToCompetitionRepository, IEntityRepository<UsersToTeam> usersToTeamRepository, IEntityRepository<User> userRepository)
		{
			_exercisesToTeamToCompetitionRepository = exercisesToTeamToCompetitionRepository;
			_usersToTeamRepository = usersToTeamRepository;
			_userRepository = userRepository;
			_exerciseRepository = exerciseRepository;
			_teamsToCompetitionRepository = teamsToCompetitionRepository;
			_competitionRepository = competitionRepository;
			_exceptionBuilderService = exceptionBuilderService;
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
				var teamsToCompetition = await _teamsToCompetitionRepository.GetActiveEntitiesWithIncludeAsync(x => x.TeamId == teamId);
				var ids = teamsToCompetition.Select(x => x.CompetitionId).ToList();
				var competitions = await _competitionRepository.GetActiveEntitiesWithIncludeAsync(x => ids.Contains(x.Id));
				competition = competitions.Where(x => x.StartDateTime <= DateTime.Now && x.EndDateTime >= DateTime.Now).FirstOrDefault();
				if (competition == null)
				{
					competitions = competitions.Where(x => x.StartDateTime >= DateTime.Now).ToList();
					if (competitions.Count > 0)
					{
						competition = competitions.First();
						foreach (var comp in competitions)
						{
							if (comp.StartDateTime < competition.StartDateTime) competition = comp;
						}
					}
					else throw _exceptionBuilderService.ParseException(ExceptionCodes.DBNoDataFoundException);
				}

				return competition;

			}
			catch
			{
				throw;
			}
		}

	}
}
