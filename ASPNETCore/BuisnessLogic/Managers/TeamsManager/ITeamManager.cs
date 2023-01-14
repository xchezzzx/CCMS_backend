using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.TeamsManager
{
	public interface ITeamManager
	{
		Task AddNewTeamAsync(TeamDT teamDT, int userCreateId);

		Task<List<TeamDT>> GetAllTeamsAsync();
	}
}
