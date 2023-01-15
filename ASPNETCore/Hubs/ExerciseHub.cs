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
		}
	}
}
