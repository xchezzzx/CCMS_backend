using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.CompetitionsManager
{
    public class CompetitionManager : ICompetitionManager
    {
        private readonly IEntityProvider<Competition> _entityProvider;

        public CompetitionManager(IEntityProvider<Competition> entityProvider)
        {
            _entityProvider = entityProvider;
        }

        public Task AddAdministratorToCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddExerciseToCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddTeamToCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateNewCompetitionAsync(CompetitionDT competitionDT, int createUserId)
        {
            var competition = ToDBModelsParsers.CompetitionParser(competitionDT);
            await _entityProvider.AddEntityAsync(competition, createUserId);
        }

        public Task DeleteCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public Task DisableCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public Task EndCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAllActiveCompetitionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompetitionDT>> GetAllCompetitionsAsync()
        {
            var competitions = await _entityProvider.GetAllEntitiesWithIncludeAsync(c => c.CreateUser, c => c.UpdateUser, c => c.Status, c => c.State);
            List<CompetitionDT> result = new List<CompetitionDT>();
            foreach(var competition in competitions)
            {
                result.Add(ToDTModelsParsers.DTCompetitionParser(competition));
            }
            return result;
        }

        public Task GetCompetitionById()
        {
            throw new NotImplementedException();
        }

        public Task RemoveAdministratorFromCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveExerciseFromCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveTeamFromCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public Task StartCompetitionAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateNewCompetitionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
