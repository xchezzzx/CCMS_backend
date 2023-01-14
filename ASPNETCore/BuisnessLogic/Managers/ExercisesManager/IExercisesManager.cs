using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.ExercisesManager
{
	public interface IExercisesManager
	{
		Task AddExerciseAsync(ExerciseDT exerciseDT, int userCreateId);

		Task<List<ExerciseDT>> GetAllExercisesAsync();
	}
}
