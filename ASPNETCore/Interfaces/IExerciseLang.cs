using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Interfaces
{
    public interface IExerciseLang
    {
        List<ExerciseLang> GetAlExerciseLanguages { get; }
        //List<ExerciseLang> GetAlActiveExerciseLanguages { get; }
        void AddNewExerciseLang(ExerciseLang lang, int userCreateId);
        void DeleteExerciseLang(ExerciseLang lang, int userUpdateId);
    }
}
