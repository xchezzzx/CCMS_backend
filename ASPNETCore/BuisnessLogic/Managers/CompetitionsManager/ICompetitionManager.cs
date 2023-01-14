using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.CompetitionsManager
{
	public interface ICompetitionManager
	{
		Task StartCompetitionAsync();
		Task EndCompetitionAsync();
		Task DisableCompetitionAsync();

		Task AddAdministratorToCompetitionAsync();
		Task RemoveAdministratorFromCompetitionAsync();

		Task AddTeamToCompetitionAsync();
		Task RemoveTeamFromCompetitionAsync();

		Task AddExerciseToCompetitionAsync();
		Task RemoveExerciseFromCompetitionAsync();

		Task<List<CompetitionDT>> GetAllCompetitionsAsync();
		Task GetAllActiveCompetitionsAsync();
		Task GetCompetitionById();
		Task CreateNewCompetitionAsync(CompetitionDT competitionDT, int userCreateId);
		Task UpdateNewCompetitionAsync();
		Task DeleteCompetitionAsync();

	}
}
