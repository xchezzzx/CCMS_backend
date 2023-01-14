using ASPNETCore.Models.DBModels;
using System.Data.Entity;

namespace ASPNETCore.Repositories
{
    public class CompetitionRepository : IRepository<Competition>
    {
        private readonly CCMSContext _dbContext;

        public CompetitionRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Competition>> GetAllCompetitions() 
        { 
            var items = await _dbContext.Competitions.AsQueryable().ToListAsync();
            return items;
        }
    }
}
