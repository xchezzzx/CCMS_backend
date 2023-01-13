using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Interfaces
{
    public interface ITeam
    {
        List<Team> GetAllTeams { get; }
        List<Team> GetAllActiveTeams { get; }
        Team GetTeamById(int teamId);
        void AddNewTeam(Team team, int userCreateId);
        void UpdateTeam(Team team, int userUpdateId);
        void DeleteTeam(Team team, int userUpdateId);
    }
}
