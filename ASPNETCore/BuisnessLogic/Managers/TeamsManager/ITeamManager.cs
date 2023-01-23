using ASPNETCore.DataAccess.Models.DBModels;
using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.TeamsManager
{
	public interface ITeamManager
	{

		Task<List<TeamDT>> GetAllTeamsAsync();
		Task<List<TeamDT>> GetActiveTeamsAsync();
		Task<TeamDT> GetTeamByIdAsync(int teamId);
		Task<TeamDT> AddNewTeamAsync(TeamDT teamDT, int userCreateId);
		Task UpdateTeamAsync(TeamDT teamDT, int userUpdateId);
		Task DeleteTeamByIdASync(int teamId, int userUpdateId);

		Task<List<UserDT>> GetAllTeamMembersAsync(int teamId);
		Task<List<CompetitionDT>> GetAllTeamCompetitionsAsync(int teamId);
		Task<CompetitionDT> GetTeamCurrentOrNearestCompetitionAsync(int teamId);
		Task<List<ExerciseDT>> GetAllCompetitionTeamExercisesAsync(int competitionId, int teamId);

		Task AddNewTeamMemberAsync(int teamId, int userId, int userCreateId);
		Task RemoveMemberFromTeamAsync(int teamId, int userId, int userUpdateId);

		Task AddNewExerciseToCompetitionTeamAsync(int competitionId, int teamId, int exerciseId, int userCreateId);
		Task RemoveExerciseFromCompetitionTeamAsync(int competitionId, int teamId, int exerciseId, int userUpdateId);

		Task MakeTeamMemberCaptainAsync(int teamId, int userId, int userUpdateId);

		Task UpdateExerciseToCompetitionTeamAsync(ExerciseToTeamToCompetitionDT exerciseToTeamToCompetitionDT, int userUpdateID);
		Task<int> GetTeamPointsInCompetitionAsync(int teamId, int competitionId);
	}
}
