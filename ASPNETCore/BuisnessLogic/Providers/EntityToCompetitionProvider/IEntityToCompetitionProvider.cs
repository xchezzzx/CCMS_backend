using ASPNETCore.DataAccess.Models.DBModels;

namespace ASPNETCore.BuisnessLogic.Providers.CompetitionsToAdministratorsProvider
{
    public interface IEntityToCompetitionProvider
	{
		Task<List<User>> GetAllCompetitionOperatorsAsync(int competitionId);
		Task<List<User>> GetAllCompetitionParticipantsAsync(int competitionId);
		Task<List<Exercise>> GetAllCompetitionExercisesAsync(int competitionId);
		Task<List<Team>> GetAllCompetitionTeamsAsync(int competitionId);
	}
}
