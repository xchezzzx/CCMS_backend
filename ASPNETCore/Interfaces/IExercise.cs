using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Interfaces
{
    public interface IExercise
    {
        List<Exercise> GetAllExercises { get; }
        List<Exercise> GetAllActiveExercises { get; }
        List<Exercise> GetExercisesByState(int exerciseStateId);
        Exercise GetExerciseById(int id);
        void AddNewExercise(Exercise exercise, int createUserId);
        void DeleteExercise(Exercise exercise, int updateUserId);
        void UpdateExercise(Exercise exercise, int updateUserId);
    }
}
