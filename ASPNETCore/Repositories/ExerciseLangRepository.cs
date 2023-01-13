using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Repositories
{
    public class ExerciseLangRepository : IExerciseLang
    {
        private readonly CCMSContext _dbContext;

        public ExerciseLangRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ExerciseLang> GetAlExerciseLanguages => _dbContext.TaskLangs.ToList();

        //public List<ExerciseLang> GetAlActiveExerciseLanguages => throw new NotImplementedException();

        public void AddNewExerciseLang(ExerciseLang lang, int userCreateId)
        {
            _dbContext.TaskLangs.Add(lang);
        }

        public void DeleteExerciseLang(ExerciseLang lang, int userUpdateId)
        {
            _dbContext.TaskLangs.Remove(lang);
        }
    }
}
