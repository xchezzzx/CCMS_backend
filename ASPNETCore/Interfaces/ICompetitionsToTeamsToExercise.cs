using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Interfaces
{
    public interface ICompetitionsToTeamsToExercise
    {
        List<CompetitionsToTeamsToExercise> GetAllCompetitionsToTeamsToExercise { get; }
        List<CompetitionsToTeamsToExercise> GetAllActiveCompetitionsToTeamsToExercise { get; }
        List<Exercise> GetAllTeamTakenExercises(int teamId, int competitionId);
        List<Team> GetTeamsTakenExercise(int exerciseId, int competitionId);
        void AddExerciseToTeam(int teamId, int competitionId, Exercise exercise, int createUserId);
        void RemoveExerciseFromTeam(int teamId, int competitionId, int exerciseId, int userUpdateId);
    }
}
