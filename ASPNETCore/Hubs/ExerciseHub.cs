using ASPNETCore.BuisnessLogic.Managers.ExercisesManager;
using Microsoft.AspNetCore.SignalR;
using SharedLib.DataTransferModels;

namespace ASPNETCore.Hubs
{
	public class ExerciseHub : Hub
	{
		private readonly IExercisesManager _exercisesManager;

		public ExerciseHub(IExercisesManager exercisesManager)
		{
			_exercisesManager = exercisesManager;
		}

		public async Task GetAllExercises()
		{
			var exercisesDT = await _exercisesManager.GetAllExercisesAsync();

			await Clients.Caller.SendAsync("GetAllExercises", exercisesDT);
		}

		public async Task AddNewExercise(ExerciseDT exerciseDT)
		{
			await _exercisesManager.AddExerciseAsync(exerciseDT, 1);
			await Clients.Caller.SendAsync("Add", "Success");
		}


		public async Task AddNewExerciseCategory(ExerciseCategoryDT exerciseCategoryDT)
		{
			await _exercisesManager.AddNewExerciseCategoryAsync(exerciseCategoryDT);
			await Clients.Caller.SendAsync("Add", "Success");

		}

		public async Task AddNewExerciseLang(ExerciseLangDT exerciseLangDT)
		{
			await _exercisesManager.AddNewExerciseLangAsync(exerciseLangDT);
			await Clients.Caller.SendAsync("Add", "Success");

		}

		public async Task GetAllExerciseCategories()
		{
			var exerciseCategoryDT = await _exercisesManager.GetAllExerciseCategoriesAsync();

			await Clients.Caller.SendAsync("Get", exerciseCategoryDT);
		}

		public async Task GetAllExerciseLangs()
		{
			var exerciseLangDT = await _exercisesManager.GetAllExerciseLangsAsync();

			await Clients.Caller.SendAsync("Get", exerciseLangDT);
		}
	}
}
