using ASPNETCore.Constants;
using ASPNETCore.Helpers;
using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using System.Data.Entity;

namespace ASPNETCore.Repositories
{
    public class CompetitionsToTeamsToExerciseRepository : ICompetitionsToTeamsToExercise
    {
        private readonly CCMSContext _dbContext;

        public CompetitionsToTeamsToExerciseRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CompetitionsToTeamsToExercise> GetAllCompetitionsToTeamsToExercise => 
            _dbContext.CompetitionsToTeamsToTasks
            .Include(cte => cte.Task)
            .Include(cte => cte.Team)
            .Include(cte => cte.Competition)
            .Include(cte => cte.CreateUser)
            .Include(cte => cte.UpdateUser)
            .ToList();

        public List<CompetitionsToTeamsToExercise> GetAllActiveCompetitionsToTeamsToExercise =>
            _dbContext.CompetitionsToTeamsToTasks
            .Include(cte => cte.Task)
            .Include(cte => cte.Team)
            .Include(cte => cte.Competition)
            .Include(cte => cte.CreateUser)
            .Include(cte => cte.UpdateUser)
            .Where(cte => cte.StatusId == (int)EntityStatuses.active)
            .ToList();

        public void AddExerciseToTeam(int teamId, int competitionId, Exercise exercise, int createUserId)
        {
            var competitionsToTeamsToExercise = new CompetitionsToTeamsToExercise(competitionId, teamId, exercise);
            FillEntityHelper.CreateEntity(ref competitionsToTeamsToExercise, createUserId);
            _dbContext.CompetitionsToTeamsToTasks.Add(competitionsToTeamsToExercise);
            _dbContext.SaveChanges();

        }

        public List<Exercise> GetAllTeamTakenExercises(int teamId, int competitionId)
        {
            return _dbContext.CompetitionsToTeamsToTasks
                .Where(cte => cte.CompetitionId == competitionId && cte.TeamId == teamId)
                .Select(cte => cte.Task)
                .Where(t => t.StatusId == (int)EntityStatuses.active)
                .Include(e => e.Category)
                .Include(e => e.Lang)
                .Include(e => e.Platform)
                .Include(e => e.CreateUser)
                .Include(e => e.UpdateUser)
                .Include(e => e.Status)
                .ToList();
        }

        public List<Team> GetTeamsTakenExercise(int exerciseId, int competitionId)
        {

            return _dbContext.CompetitionsToTeamsToTasks
                .Where(cte => cte.CompetitionId == competitionId && cte.TaskId == exerciseId)
                .Select(cte => cte.Team)
                .Where(t => t.StatusId == (int)EntityStatuses.active)
                .Include(t => t.Status)
                .Include(t => t.CreateUser)
                .Include(t => t.UpdateUser)
                .ToList();
        }

        public void RemoveExerciseFromTeam(int teamId, int competitionId, int exerciseId, int userUpdateId)
        {
            var compTeamEx = _dbContext.CompetitionsToTeamsToTasks.Where(cte => cte.TeamId == teamId && cte.TaskId == exerciseId && cte.CompetitionId == competitionId).FirstOrDefault();

            if (compTeamEx != null)
            {
                FillEntityHelper.DeleteEntity(ref compTeamEx, userUpdateId);
                _dbContext.CompetitionsToTeamsToTasks.Update(compTeamEx);
                _dbContext.SaveChanges();
            }
        }
    }
}
