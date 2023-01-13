using ASPNETCore.Models.DBModels;

namespace ASPNETCore.InterfacesPlatform
{
    public interface IExercisePlatform
    {
        List<ExercisePlatform> GetAllExercisePlatforms { get; }
        List<ExercisePlatform> GetAllActiveExercisePlatforms { get; }
        void AddNewExercisePlatform(ExercisePlatform platform, int userCreateId);
        void DeleteExercisePlatform(ExercisePlatform platform, int userUpdateId);
    }
}
