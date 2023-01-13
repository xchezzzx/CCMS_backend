using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Interfaces
{
    public interface ICompetitionToTeamsToUser
    {
        List<CompetitionsToTeamsToUser> GetAllCompetitionsToTeamsToUser{ get; }
        List<CompetitionsToTeamsToUser> GetAllActiveCompetitionsToTeamsToUser { get; }
        List<User> GetParticipantsByCompetitionId(int competitionId);
        void AddUserToTeamToCompetiton(int userId, int competitionId, int teamId, int userCreateId);
        void SwitchUserTeam(int userId, int competitionId, int teamId, int newTeamId, int userUpdateId);
        bool IfUserIsCompetitionParticipant(int userId, int competitionId);
        void DeleteUserFromTeamFromCompetition(int userId, int competitionId, int teamId, int userUpdateId);
        void MakeUserCaptain(int userId, int competitionId, int teamId, int userUpdateId);
        bool IfUserIsCaptain(int userId, int competitionId, int teamId);
    }
}
    