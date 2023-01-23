using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;

namespace ASPNETCore.BuisnessLogic.Managers.ExercisesManager
{
	public class ExercisesManager : IExercisesManager
	{
		private readonly IEntityProvider<Exercise> _entityProviderExercise;
		private readonly IEntityProvider<ExerciseLang> _entityProviderExerciseLang;
		private readonly IEntityProvider<ExerciseCategory> _entityProviderExerciseCategory;
		private readonly IEntityProvider<ExercisePlatform> _entityProviderExercisePlatform;

		public ExercisesManager(IEntityProvider<Exercise> entityProviderExercise, IEntityProvider<ExerciseLang> entityProviderExerciseLang, IEntityProvider<ExerciseCategory> entityProviderExerciseCategory, IEntityProvider<ExercisePlatform> entityProviderExercisePlatform, IExceptionBuilderService exceptionBuilderService)
		{
			_entityProviderExercise = entityProviderExercise;
			_entityProviderExerciseLang = entityProviderExerciseLang;
			_entityProviderExerciseCategory = entityProviderExerciseCategory;
			_entityProviderExercisePlatform = entityProviderExercisePlatform;
		}

		public async Task<List<ExerciseDT>> GetAllExercisesAsync()
		{
			List<Exercise> exercises;

			try
			{
				exercises = await _entityProviderExercise.GetAllEntitiesWithIncludeAsync(c => c.CreateUser, e => e.UpdateUser, e => e.Lang, e => e.Platform, e => e.Category);
			}
			catch
			{
				throw;
			}

			List<ExerciseDT> result = new List<ExerciseDT>();
			
			foreach(var exercise in exercises)
			{
				result.Add(ToDTModelsParsers.DTExerciseParser(exercise));
			}
			return result;
		}

		public async Task<ExerciseDT> AddNewExerciseAsync(ExerciseDT exerciseDT, int userCreateId)
		{
			try
			{
				var exercise = ToDBModelsParsers.ExerciseParser(exerciseDT);
				exercise = await _entityProviderExercise.AddNewEntityAsync(exercise, userCreateId);
				exerciseDT = ToDTModelsParsers.DTExerciseParser(exercise);
				return exerciseDT;
			}
			catch 
			{
				throw;
			}
		}

		public async Task<List<ExerciseLangDT>> GetAllExerciseLangsAsync()
		{
			List<ExerciseLang> langs;
			try
			{
				langs = await _entityProviderExerciseLang.GetAllEntitiesWithIncludeAsync();
			}
			catch
			{
				throw;
			}

			var result = new List<ExerciseLangDT>();
			foreach(var lang in langs)
			{
				result.Add(ToDTModelsParsers.DTExerciseLanguageParser(lang));
			}

			return result;
		}

		public async Task<List<ExerciseCategoryDT>> GetAllExerciseCategoriesAsync()
		{
			List<ExerciseCategory> categories;
			try
			{
				categories = await _entityProviderExerciseCategory.GetAllEntitiesWithIncludeAsync();
			}
			catch
			{
				throw;
			}

			var result = new List<ExerciseCategoryDT>();
			foreach (var category in categories)
			{
				result.Add(ToDTModelsParsers.DTExerciseCategoryParser(category));
			}

			return result;
		}

		public async Task<List<ExercisePlatformDT>> GetAllExercisePlatformsAsync()
		{
			List<ExercisePlatform> platforms;
			try
			{
				platforms = await _entityProviderExercisePlatform.GetAllEntitiesWithIncludeAsync();
			}
			catch
			{
				throw;
			}

			var result = new List<ExercisePlatformDT>();
			foreach (var platform in platforms)
			{
				result.Add(ToDTModelsParsers.DTExercisePlatformParser(platform));
			}

			return result;
		}

		public async Task<ExerciseLangDT> AddNewExerciseLangAsync(ExerciseLangDT exerciseLangDT)
		{
			var exerciseLang = ToDBModelsParsers.ExerciseLangParser(exerciseLangDT);
			try
			{
				exerciseLang = await _entityProviderExerciseLang.AddNewEntityAsync(exerciseLang, 1);
				exerciseLangDT = ToDTModelsParsers.DTExerciseLanguageParser(exerciseLang);
				return exerciseLangDT;
			}
			catch
			{
				throw;
			}
		}

		public async Task<ExerciseCategoryDT> AddNewExerciseCategoryAsync(ExerciseCategoryDT exerciseCategoryDT)
		{
			var exerciseCategory = ToDBModelsParsers.ExerciseCategoryParser(exerciseCategoryDT);

			try
			{
				exerciseCategory = await _entityProviderExerciseCategory.AddNewEntityAsync(exerciseCategory, 1);
				exerciseCategoryDT = ToDTModelsParsers.DTExerciseCategoryParser(exerciseCategory);
				return exerciseCategoryDT;
			}
			catch
			{
				throw;
			}

		}

		public async Task<ExercisePlatformDT> AddNewExercisePlatformAsync(ExercisePlatformDT exercisePlatformDT)
		{
			var exercisePlatform = ToDBModelsParsers.ExercisePlatformParser(exercisePlatformDT);

			try
			{
				exercisePlatform = await _entityProviderExercisePlatform.AddNewEntityAsync(exercisePlatform, 1);
				exercisePlatformDT = ToDTModelsParsers.DTExercisePlatformParser(exercisePlatform);
				return exercisePlatformDT;
			}
			catch
			{
				throw;
			}
		}
	}
}
