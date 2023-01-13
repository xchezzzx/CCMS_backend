using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Interfaces
{
    public interface IExerciseCategory
    {
        List<ExerciseCategory> GetAlIExerciseCategories { get; }
        //List<ExerciseCategory> GetAlIActiveExerciseCategories { get; }
        void AddNewExerciseCategory(ExerciseCategory category, int userCreateId);
        void DeleteExerciseCategory(ExerciseCategory category, int userUpdateId);
    }
}
