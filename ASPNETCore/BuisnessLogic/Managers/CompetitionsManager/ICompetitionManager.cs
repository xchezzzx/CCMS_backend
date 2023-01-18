using ASPNETCore.DataAccess.Models.DBModels;
using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.CompetitionsManager
{
	public interface ICompetitionManager
	{

		Task AddNewOperatorToCompetitionAsync(int competitionId, int operatorId, int createUserId);
		Task RemoveOperatorFromCompetitionAsync(int competitionId, int operatorId, int updateUserId);


		Task AddNewTeamToCompetitionAsync(int competitionId, int teamId, int createUserId);
		Task RemoveTeamFromCompetitionAsync(int competitionId, int teamId, int updateUserId);

		Task AddNewExerciseToCompetitionAsync(int competitionId, int exerciseId, int createUserId);
		Task RemoveExerciseFromCompetitionAsync(int competitionId, int exerciseId, int updateUserId);

		Task<List<CompetitionDT>> GetAllCompetitionsAsync();
		Task<List<CompetitionDT>> GetActiveCompetitionsAsync();
		Task<CompetitionDT> GetCompetitionByIdAsync(int competitionId);
		Task<CompetitionDT> AddNewCompetitionAsync(CompetitionDT competitionDT, int userCreateId); 
		Task UpdateCompetitionAsync(CompetitionDT competitionDT, int updateUserId);
		Task DeleteCompetitionByIdAsync(int competitionId, int updateUserId);
		Task DisableCompetitionByIdAsync(int competitionId, int updateUserId);
		Task StartCompetitionByIdAsync(int competitionId, int updateUserId);
		Task EndCompetitionByIdAsync(int competitionId, int updateUserId);

		Task<List<UserDT>> GetAllCompetitionOperatorsAsync(int competitionId);
		Task<List<UserDT>> GetAllCompetitionParticipantsAsync(int competitionId);
		Task<List<ExerciseDT>> GetAllCompetitionExercisesAsync(int competitionId);
		Task<List<TeamDT>> GetAllCompetitionTeamsAsync(int competitionId);

	}
}
