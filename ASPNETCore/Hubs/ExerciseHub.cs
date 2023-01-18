using ASPNETCore.BuisnessLogic.Managers.ExercisesManager;
using Microsoft.AspNetCore.SignalR;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;

namespace ASPNETCore.Hubs
{
	public class ExerciseHub : Hub
	{
		private readonly IExercisesManager _exercisesManager;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public ExerciseHub(IExercisesManager exercisesManager, IExceptionBuilderService exceptionBuilderService)
		{
			_exercisesManager = exercisesManager;
			_exceptionBuilderService = exceptionBuilderService;
		}

		public async Task GetAllExercises()
		{
			List<ExerciseDT> exercisesDT;
			try
			{
				exercisesDT = await _exercisesManager.GetAllExercisesAsync();
			}
			catch
			{
				throw;
			}

			await Clients.Caller.SendAsync("GetAllExercises", exercisesDT);
		}

		public async Task AddNewExercise(ExerciseDT exerciseDT)
		{
			string res = "Success";
			try
			{
				if (exerciseDT == null)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(exerciseDT));
				}
				await _exercisesManager.AddExerciseAsync(exerciseDT, 1);
			}
			catch
			{
				res = "failed";
			}
			await Clients.Caller.SendAsync("Add", res);
		}


		public async Task AddNewExerciseCategory(ExerciseCategoryDT exerciseCategoryDT)
		{

			string res = "Success";
			try
			{
				if (exerciseCategoryDT == null)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(exerciseCategoryDT));
				}
				await _exercisesManager.AddNewExerciseCategoryAsync(exerciseCategoryDT);
			}
			catch
			{
				res = "failed";
			}
			await Clients.Caller.SendAsync("Add", res);

		}

		public async Task AddNewExerciseLang(ExerciseLangDT exerciseLangDT)
		{

			string res = "Success";
			try
			{
				if (exerciseLangDT == null)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(exerciseLangDT));
				}
				await _exercisesManager.AddNewExerciseLangAsync(exerciseLangDT);
			}
			catch
			{
				res = "failed";
			}
			await Clients.Caller.SendAsync("Add", res);

		}

		public async Task GetAllExerciseCategories()
		{
			List<ExerciseCategoryDT> exerciseCategoryDT;
			try
			{
				exerciseCategoryDT = await _exercisesManager.GetAllExerciseCategoriesAsync();
			}
			catch
			{
				throw;
			}

			await Clients.Caller.SendAsync("Get", exerciseCategoryDT);
		}

		public async Task GetAllExerciseLangs()
		{
			List<ExerciseLangDT> exerciseLangDT;
			try
			{
				exerciseLangDT = await _exercisesManager.GetAllExerciseLangsAsync();
			}
			catch
			{
				throw;
			}

			await Clients.Caller.SendAsync("Get", exerciseLangDT);
		}

		public async Task GetAllExercisePlatforms()
		{

			List<ExercisePlatformDT> exercisePlatformDT;
			try
			{
				exercisePlatformDT = await _exercisesManager.GetAllExercisePlatformsAsync();
			}
			catch
			{
				throw;
			}

			await Clients.Caller.SendAsync("Get", exercisePlatformDT);
		}

		public async Task AddNewExercisePlatform(ExercisePlatformDT exercisePlatformDT)
		{
			string res = "Success";
			try
			{
				if (exercisePlatformDT == null)
				{
					throw _exceptionBuilderService.ParseException(SharedLib.Constants.Enums.ExceptionCodes.HubMethodNullArgumentException, nameof(exercisePlatformDT));
				}
				await _exercisesManager.AddNewExercisePlatformAsync(exercisePlatformDT);
			}
			catch
			{
				res = "failed";
			}
			await Clients.Caller.SendAsync("Add", res);

		}

	}
}
