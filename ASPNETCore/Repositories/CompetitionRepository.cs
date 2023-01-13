using ASPNETCore.Helpers;
using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore.Repositories
{
    public class CompetitionRepository : ICompetition
    {
        private readonly CCMSContext _modelsContext;

        public CompetitionRepository(CCMSContext modelsContext)
        {
            _modelsContext = modelsContext;
        }


        public List<Competition> GetAllCompetitions => 
            _modelsContext.Competitions
            .Include(c => c.State)
            .Include(c => c.Status)
            .Include(c => c.CreateUser)
            .Include(c => c.UpdateUser)
            .ToList();

        public Competition GetCompetitionById(int id) =>
           (_modelsContext.Competitions
            .Include(c => c.State)
            .Include(c => c.Status)
            .Include(c => c.CreateUser)
            .Include(c => c.UpdateUser)
            .Where(c => c.Id == id)
            .FirstOrDefault());

        public void AddNewCompetiton(Competition competition, int createUserID)
        {
            FillEntityHelper.CreateEntity(ref competition, createUserID);
            _modelsContext.Competitions.Add(competition);
            _modelsContext.SaveChanges();
            //return true;
        }

        public void UpdeteCompetiton(Competition competition, int updateUserID)
        {
            FillEntityHelper.UpdateEntity(ref competition, updateUserID);
            _modelsContext.Competitions.Update(competition);
            _modelsContext.SaveChanges();
        }

        public void DeleteCompetiton(Competition competition, int updateUserID)
        {
            FillEntityHelper.DeleteEntity(ref competition, updateUserID);
            _modelsContext.Competitions.Update(competition);
            _modelsContext.SaveChanges();
        }

        public void UpdateCompetition(Competition competition, int userCreateId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetParticipantsByCompetitionId(int competitionId)
        {
            throw new NotImplementedException();
        }

        public void AddUserToTeamToCompetiton(int userId, int competitionId, int teamId)
        {
            throw new NotImplementedException();
        }

        public void SwitchUserTeam(int userId, int competitionId, int newTeamId)
        {
            throw new NotImplementedException();
        }

        public bool IfUserIsCompetitionParticipant(int userId, int competitionId)
        {
            throw new NotImplementedException();
        }
    }
}
