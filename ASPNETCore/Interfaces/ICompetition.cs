using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Interfaces
{
    public interface ICompetition
    {
        List<Competition> GetAllCompetitions { get; }
        List<Competition> GetAllActiveCompetitions { get; }
        Competition GetCompetitionById(int competitionId);
        void AddNewCompetiton(Competition competition, int userCreateId);
        void DeleteCompetiton(Competition competition, int userCreateId);
        void UpdateCompetition(Competition competition, int userCreateId);
    }
}
