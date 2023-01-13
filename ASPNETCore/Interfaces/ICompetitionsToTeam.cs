using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Interfaces
{
    public interface ICompetitionsToTeam
    {
        List<CompetitionsToTeam> GetAllCompetitionsToTeam { get; }
        List<CompetitionsToTeam> GetAllActiveCompetitionsToTeam { get; }
        List<Competition> GetCompetitionsByTeamId(int teamId);
        List<Team> GetTeamsByCompetitionId (int competitionId);
        void AddTeamToCompetiton(int competitionId, int teamId, int userCreateId );
        void RemoveTeamFromCompetiton(CompetitionsToTeam competitionsToTeam, int userUpdateId);
    }
}
