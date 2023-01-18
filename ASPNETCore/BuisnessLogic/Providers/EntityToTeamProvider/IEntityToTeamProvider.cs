using ASPNETCore.DataAccess.Models.DBModels;

namespace ASPNETCore.BuisnessLogic.Providers.EntityToTeamProvider
{
    public interface IEntityToTeamProvider
	{
		Task<List<User>> GetAllTeamMembersAsync(int teamId);
		Task<List<Competition>> GetAllTeamCompetitionsAsync(int teamId);
		Task<Competition> GetTeamCurrentOrNearestCompetitionAsync(int teamId);
		Task<List<Exercise>> GetAllCompetitionTeamExercisesAsync(int competitionId, int teamId);
	}
}
