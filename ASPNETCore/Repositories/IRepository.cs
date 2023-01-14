using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Repositories
{
    public interface IRepository<T>
    {
		Task<List<T>> GetAllCompetitions();
    }
}
