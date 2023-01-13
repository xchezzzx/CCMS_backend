using ASPNETCore.Constants;
using ASPNETCore.Helpers;
using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore.Repositories
{
    public class CompetitionToTeamsToUserRepository : ICompetitionToTeamsToUser
    {
        private readonly CCMSContext _dbContext;

        public CompetitionToTeamsToUserRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CompetitionsToTeamsToUser> GetAllCompetitionsToTeamsToUser => _dbContext.CompetitionsToTeamsToUsers
            .Include(ctu => ctu.Status)
            .Include(ctu => ctu.CreateUser)
            .Include(ctu => ctu.UpdateUser)
            .ToList();

        public List<CompetitionsToTeamsToUser> GetAllActiveCompetitionsToTeamsToUser => _dbContext.CompetitionsToTeamsToUsers
            .Include(ctu => ctu.Status)
            .Include(ctu => ctu.CreateUser)
            .Include(ctu => ctu.UpdateUser)
            .Where(ctu => ctu.StatusId == (int)EntityStatuses.active)
            .ToList();


        public void AddUserToTeamToCompetiton(int userId, int competitionId, int teamId, int userCreateId)
        {
            var CompTeamsUser = new CompetitionsToTeamsToUser(userId, competitionId, teamId);

            FillEntityHelper.CreateEntity(ref CompTeamsUser, userCreateId);
            _dbContext.CompetitionsToTeamsToUsers.Add(CompTeamsUser);
            _dbContext.SaveChanges();
        }

        public void DeleteUserFromTeamFromCompetition(int userId, int competitionId, int teamId, int userUpdateId)
        {
            var CompTeamsUser = _dbContext.CompetitionsToTeamsToUsers
                .Where(ctu => ctu.UserId == userId && ctu.TeamId == teamId && ctu.CompetitionId == competitionId)
                .FirstOrDefault();

            FillEntityHelper.UpdateEntity(ref CompTeamsUser, userUpdateId);
            _dbContext.CompetitionsToTeamsToUsers.Add(CompTeamsUser);
            _dbContext.SaveChanges();
        }

        public List<User> GetParticipantsByCompetitionId(int competitionId)
        {
            return _dbContext.CompetitionsToTeamsToUsers
                .Where(ctu => ctu.CompetitionId == competitionId && ctu.StatusId == (int)EntityStatuses.active)
                .Include(ctu => ctu.User)
                .Select(ctu => ctu.User)
                .Include(u => u.Role)
                .Include(u => u.Status)
                .Include(u => u.UpdateUser)
                .Include(u => u.CreateUser)
                .Where(u => u.StatusId == (int)EntityStatuses.active)
                .ToList();
        }


        public List<User> GetParticipantsByTeamId(int competitionId, int teamId)
        {
            return _dbContext.CompetitionsToTeamsToUsers
                .Where(ctu => ctu.CompetitionId == competitionId && ctu.TeamId == teamId && ctu.StatusId == (int)EntityStatuses.active)
                .Include(ctu => ctu.User)
                .Select(ctu => ctu.User)
                .Include(u => u.Role)
                .Include(u => u.Status)
                .Include(u => u.UpdateUser)
                .Include(u => u.CreateUser)
                .Where(u => u.StatusId == (int)EntityStatuses.active)
                .ToList();
        }

        public bool IfUserIsCompetitionParticipant(int userId, int competitionId)
        {
            return _dbContext.CompetitionsToTeamsToUsers
                .Where(ctu => ctu.CompetitionId == competitionId && ctu.UserId == userId && ctu.StatusId == (int)EntityStatuses.active)
                .FirstOrDefault() != null;
        }

        public void MakeUserCaptain(int userId, int competitionId, int teamId, int userUpdateId)
        {
            var CompTeamsUser = _dbContext.CompetitionsToTeamsToUsers
                .Where(ctu => ctu.UserId == userId && ctu.CompetitionId == competitionId && ctu.TeamId == teamId)
                .FirstOrDefault();
            if (CompTeamsUser != null)
            {
                CompTeamsUser.IsCaptain = true;
                FillEntityHelper.UpdateEntity(ref CompTeamsUser, userUpdateId);
                _dbContext.CompetitionsToTeamsToUsers.Update(CompTeamsUser);
                _dbContext.SaveChanges();
            }
        }

        public bool IfUserIsCaptain(int userId, int competitionId, int teamId)
        {
            return _dbContext.CompetitionsToTeamsToUsers
                .Where(ctu => ctu.UserId == userId && ctu.CompetitionId == competitionId && ctu.TeamId == teamId)
                .FirstOrDefault().IsCaptain;
        }

        public void SwitchUserTeam(int userId, int competitionId, int teamId, int newTeamId, int userUpdateId)
        {
            var CompTeamsUser = _dbContext.CompetitionsToTeamsToUsers
                .Where(ctu => ctu.UserId == userId && ctu.CompetitionId == competitionId && ctu.TeamId == teamId)
                .FirstOrDefault();
            if (CompTeamsUser != null)
            {
                CompTeamsUser.TeamId = newTeamId;
                FillEntityHelper.UpdateEntity(ref CompTeamsUser, userUpdateId);
                _dbContext.CompetitionsToTeamsToUsers.Update(CompTeamsUser);
                _dbContext.SaveChanges();
            }
        }
    }
}
