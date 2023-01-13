using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using System.Data.Entity;

namespace ASPNETCore.Repositories
{
    public class ExerciseCategoryRepository : IExerciseCategory
    {
        private readonly CCMSContext _dbContext;

        public ExerciseCategoryRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ExerciseCategory> GetAlIExerciseCategories => _dbContext.TaskCategories.ToList();

        //public List<ExerciseCategory> GetAlIActiveExerciseCategories => throw new NotImplementedException();

        public void AddNewExerciseCategory(ExerciseCategory category, int userCreateId)
        {
            _dbContext.TaskCategories.Add(category);
        }

        public void DeleteExerciseCategory(ExerciseCategory category, int userUpdateId)
        {
            _dbContext.TaskCategories.Remove(category);
        }
    }
}
