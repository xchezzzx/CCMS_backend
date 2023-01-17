using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.TeamsManager
{
	public interface ITeamManager
	{
		Task AddNewTeamAsync(TeamDT teamDT, int userCreateId);

		Task<List<TeamDT>> GetAllTeamsAsync();
		Task<List<TeamDT>> GetActiveTeamsAsync();
		Task<TeamDT> GetTeamByIdAsync(int teamId);
		Task UpdateTeamAsync(TeamDT teamDT, int userUpdateId);
		Task DeleteTeamByIdASync(int teamId, int userUpdateId);

		Task<List<UserDT>> GetAllTeamMembersAsync(int teamId);
		Task<List<CompetitionDT>> GetAllTeamCompetitionsAsync(int teamId);
		Task<List<CompetitionDT>> GetAllTeamСгккутеCompetitionAsync(int teamId);
		Task<List<ExerciseDT>> GetAllCompetitionTeamExercisesAsync(int competitionId, int teamId);

		Task AddNewTeamMemberAsync(int teamId, int userId);
		Task RemoveMemberFromTeamAsync(int teamId, int userId);

		Task AddNewCompetitionTeamExerciseAsync(int teamId, int userId);
		Task RemoveExeerciseFromCompetitionTeamAsync(int teamId, int userId);

	}
}
