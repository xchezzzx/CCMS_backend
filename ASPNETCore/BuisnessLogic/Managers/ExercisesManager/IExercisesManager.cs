using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.ExercisesManager
{
	public interface IExercisesManager
	{
		Task AddExerciseAsync(ExerciseDT exerciseDT, int userCreateId);

		Task<List<ExerciseDT>> GetAllExercisesAsync();

		Task<List<ExerciseLangDT>> GetAllExerciseLangsAsync();
		Task<List<ExerciseCategoryDT>> GetAllExerciseCategoriesAsync();

		Task AddNewExerciseLangAsync(ExerciseLangDT exerciseLangDT);
		Task AddNewExerciseCategoryAsync(ExerciseCategoryDT exerciseCategoryDT);
	}
}
