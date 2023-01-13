using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using System.Data.Entity;

namespace ASPNETCore.Repositories
{
    public class TeamRepository : ITeam
    {
        private readonly CCMSContext _dbContext;

        public TeamRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Team> GetAllTeams => _dbContext.Teams
            .Include(t => t.Status)
            .Include(t => t.UpdateUser)
            .Include(t => t.CreateUser)
            .ToList();

        public List<Team> GetAllActiveTeams => throw new NotImplementedException();

        public void AddNewTeam(Team team, int userCreateId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(Team team, int userUpdateId)
        {
            throw new NotImplementedException();
        }

        public Team GetTeamById(int teamId)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(Team team, int userUpdateId)
        {
            throw new NotImplementedException();
        }
    }
}
