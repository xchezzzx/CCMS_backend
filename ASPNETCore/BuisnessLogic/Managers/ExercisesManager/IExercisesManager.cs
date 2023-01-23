using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.ExercisesManager
{
	public interface IExercisesManager
	{
		Task<ExerciseDT> AddNewExerciseAsync(ExerciseDT exerciseDT, int userCreateId);

		Task<List<ExerciseDT>> GetAllExercisesAsync();

		Task<List<ExerciseLangDT>> GetAllExerciseLangsAsync();
		Task<List<ExerciseCategoryDT>> GetAllExerciseCategoriesAsync();
		Task<List<ExercisePlatformDT>> GetAllExercisePlatformsAsync();

		Task<ExerciseLangDT> AddNewExerciseLangAsync(ExerciseLangDT exerciseLangDT);
		Task<ExerciseCategoryDT> AddNewExerciseCategoryAsync(ExerciseCategoryDT exerciseCategoryDT);
		Task<ExercisePlatformDT> AddNewExercisePlatformAsync(ExercisePlatformDT exerciseCategoryDT);
	}
}
