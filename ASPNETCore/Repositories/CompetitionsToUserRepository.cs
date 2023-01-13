using ASPNETCore.Constants;
using ASPNETCore.Helpers;
using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using System.Data.Entity;

namespace ASPNETCore.Repositories
{
    public class CompetitionsToUserRepository : ICompetitionsToUser
    {
        private readonly CCMSContext _dbContext;

        public CompetitionsToUserRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CompetitionsToUser> GetAllCompetitionsToUser => _dbContext.CompetitionsToUsers
            .Include(cu => cu.CreateUserId)
            .Include(cu => cu.UpdateUserId)
            .Include(cu => cu.Status)
            .ToList();

        public List<CompetitionsToUser> GetAllActiveCompetitionsToUser => _dbContext.CompetitionsToUsers
            .Where(cu => cu.StatusId == (int)EntityStatuses.active)
            .Include(cu => cu.CreateUserId)
            .Include(cu => cu.UpdateUserId)
            .Include(cu => cu.Status)
            .ToList();

        public void AddAdministratorToCompetiton(int competitionId, int administratorId, int userCreateId)
        {
            var sdmin = new CompetitionsToUser(competitionId, administratorId);
            FillEntityHelper.CreateEntity(ref sdmin, userCreateId);
            _dbContext.CompetitionsToUsers.Add(sdmin);
            _dbContext.SaveChanges();
        }

        public List<User> GetAdministratorsByCompetitionId(int competitionId)
        {
            return _dbContext.CompetitionsToUsers
                .Where(cu => cu.CompetitionId == competitionId && cu.StatusId == (int)EntityStatuses.active)
                .Include(cu => cu.User)
                .Select(cu => cu.User)
                .Include(cu => cu.CreateUserId)
                .Include(cu => cu.UpdateUserId)
                .Include(cu => cu.Status)
                .Include(cu => cu.Role)
                .ToList();
        }

        public List<Competition> GetCompetitionsByAdministratorId(int administratorId)
        {
            return _dbContext.CompetitionsToUsers
                .Where(cu => cu.UserId == administratorId && cu.StatusId == (int)EntityStatuses.active)
                .Include(cu => cu.Competition)
                .Select(cu => cu.Competition)
                .Include(cu => cu.CreateUserId)
                .Include(cu => cu.UpdateUserId)
                .Include(cu => cu.Status)
                .Include(cu => cu.State)
                .ToList();
        }

        public bool IfUserIsCompetitionAdministrator(int competitionId, int administratorId)
        {
            return _dbContext.CompetitionsToUsers
                .Where(cu => cu.UserId == administratorId && cu.CompetitionId == competitionId && cu.StatusId == (int)EntityStatuses.active)
                .FirstOrDefault() != null;
        }

        public void RemoveAdministratorFromCompetition(int competitionId, int administratorId, int userUpdateId)
        {
            var admin = _dbContext.CompetitionsToUsers
                .Where(cu => cu.UserId == administratorId && cu.CompetitionId == competitionId && cu.StatusId == (int)EntityStatuses.active)
                .FirstOrDefault();

            if (admin != null)
            {
                FillEntityHelper.DeleteEntity(ref admin, userUpdateId);
                _dbContext.CompetitionsToUsers.Update(admin);
                _dbContext.SaveChanges();
            }
        }
    }
}
