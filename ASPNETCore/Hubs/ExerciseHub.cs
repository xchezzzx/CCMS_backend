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
			
			try
			{
				if (exerciseDT == null)
				{
					throw _exceptionBuilderService.ParseException(ExceptionCodes.HubMethodNullArgumentException, nameof(exerciseDT));
				}
				exerciseDT = await _exercisesManager.AddNewExerciseAsync(exerciseDT, 1);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("AddNewExercise", exerciseDT);
		}


		public async Task AddNewExerciseCategory(ExerciseCategoryDT exerciseCategoryDT)
		{

			try
			{
				if (exerciseCategoryDT == null)
				{
					throw _exceptionBuilderService.ParseException(ExceptionCodes.HubMethodNullArgumentException, nameof(exerciseCategoryDT));
				}
				exerciseCategoryDT = await _exercisesManager.AddNewExerciseCategoryAsync(exerciseCategoryDT);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("AddNewExerciseCategory", exerciseCategoryDT);

		}

		public async Task AddNewExerciseLang(ExerciseLangDT exerciseLangDT)
		{

			try
			{
				if (exerciseLangDT == null)
				{
					throw _exceptionBuilderService.ParseException(ExceptionCodes.HubMethodNullArgumentException, nameof(exerciseLangDT));
				}
				exerciseLangDT = await _exercisesManager.AddNewExerciseLangAsync(exerciseLangDT);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("AddNewExerciseLang", exerciseLangDT);

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

			await Clients.Caller.SendAsync("GetAllExerciseCategories", exerciseCategoryDT);
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

			await Clients.Caller.SendAsync("GetAllExerciseLangs", exerciseLangDT);
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

			await Clients.Caller.SendAsync("GetAllExercisePlatforms", exercisePlatformDT);
		}

		public async Task AddNewExercisePlatform(ExercisePlatformDT exercisePlatformDT)
		{
			try
			{
				if (exercisePlatformDT == null)
				{
					throw _exceptionBuilderService.ParseException(ExceptionCodes.HubMethodNullArgumentException, nameof(exercisePlatformDT));
				}
				exercisePlatformDT = await _exercisesManager.AddNewExercisePlatformAsync(exercisePlatformDT);
			}
			catch
			{
				throw;
			}
			await Clients.Caller.SendAsync("AddNewExercisePlatform", exercisePlatformDT);

		}
	}
}
