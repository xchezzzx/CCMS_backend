using ASPNETCore.InterfacesPlatform;
using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Repositories
{
    public class ExercisePlatformRepository : IExercisePlatform
    {
        private readonly CCMSContext _dbContext;

        public ExercisePlatformRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ExercisePlatform> GetAllExercisePlatforms => _dbContext.TaskPlatforms.ToList();

        //public List<ExercisePlatform> GetAllActiveExercisePlatforms => throw new NotImplementedException();

        public void AddNewExercisePlatform(ExercisePlatform platform)
        {
            _dbContext.TaskPlatforms.Add(platform);
        }

        public void DeleteExercisePlatform(ExercisePlatform platform)
        {
            _dbContext.TaskPlatforms.Remove(platform);
        }
    }
}
