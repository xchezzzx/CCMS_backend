using ASPNETCore.Constants;
using ASPNETCore.Helpers;
using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore.Repositories
{
    public class CompetitionsToTeamRepository : ICompetitionsToTeam
    {
        private readonly CCMSContext _dbContext;

        public CompetitionsToTeamRepository(CCMSContext context)
        {
            _dbContext = context;
        }


        public List<CompetitionsToTeam> GetAllCompetitionsToTeam => 
            _dbContext.CompetitionsToTeams
            .Include(ct => ct.CreateUser)
            .Include(ct => ct.UpdateUser)
            .ToList();

        public List<CompetitionsToTeam> GetAllActiveCompetitionsToTeam => 
            _dbContext.CompetitionsToTeams
            .Where(ct => ct.StatusId == (int)EntityStatuses.active)
            .Include(ct => ct.CreateUser)
            .Include(ct => ct.UpdateUser)
            .ToList();

        public void AddTeamToCompetiton(int competitionId, int teamId, int userCreateId)
        {
            var teamToCompetition = new CompetitionsToTeam(competitionId, teamId);
            FillEntityHelper.CreateEntity(ref teamToCompetition, userCreateId);
            _dbContext.CompetitionsToTeams.Add(teamToCompetition);
            _dbContext.SaveChanges();
        }

        public List<Competition> GetCompetitionsByTeamId(int teamId)
        {
            return _dbContext.CompetitionsToTeams
                .Where(ct => ct.TeamId == teamId)
                .Select(ct => ct.Competition)
                .Where(c => c.StatusId == (int)EntityStatuses.active)
                .Include(c => c.State)
                .Include(c => c.Status)
                .Include(c => c.CreateUser)
                .Include(c => c.UpdateUser)
                .ToList();
        }

        public List<Team> GetTeamsByCompetitionId(int competitionId)
        {
            return _dbContext.CompetitionsToTeams
                .Where(ct => ct.CompetitionId == competitionId)
                .Select(ct => ct.Team)
                .Where(t => t.StatusId == (int)EntityStatuses.active)
                .Include(t => t.Status)
                .Include(t => t.CreateUser)
                .Include(t => t.UpdateUser)
                .ToList();
        }

        public void RemoveTeamFromCompetiton(CompetitionsToTeam competitionsToTeam, int userUpdateId)
        {
            FillEntityHelper.DeleteEntity(ref competitionsToTeam, userUpdateId);
            _dbContext.CompetitionsToTeams.Update(competitionsToTeam);
            _dbContext.SaveChanges();
        }
    }
}
