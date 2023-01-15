using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.DataAccess.Repositories;
using ASPNETCore.Helpers;
using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.ExercisesManager
{
	public class ExercisesManager : IExercisesManager
	{
		private readonly IEntityProvider<Exercise> _entityProviderExercise;
		private readonly IEntityProvider<ExerciseLang> _entityProviderExerciseLang;
		private readonly IEntityProvider<ExerciseCategory> _entityProviderExerciseCategory;
		private readonly IEntityProvider<ExercisePlatform> _entityProviderExercisePlatform;

		public ExercisesManager(IEntityProvider<Exercise> entityProviderExercise, IEntityProvider<ExerciseLang> entityProviderExerciseLang, IEntityProvider<ExerciseCategory> entityProviderExerciseCategory, IEntityProvider<ExercisePlatform> entityProviderExercisePlatform)
		{
			_entityProviderExercise = entityProviderExercise;
			_entityProviderExerciseLang = entityProviderExerciseLang;
			_entityProviderExerciseCategory = entityProviderExerciseCategory;
			_entityProviderExercisePlatform = entityProviderExercisePlatform;
		}

		public async Task<List<ExerciseDT>> GetAllExercisesAsync()
		{
			var exercises = await _entityProviderExercise.GetAllEntitiesWithIncludeAsync(c => c.CreateUser, e => e.UpdateUser, e => e.Lang, e => e.Platform, e => e.Category);

			List<ExerciseDT> result = new List<ExerciseDT>();
			
			foreach(var exercise in exercises)
			{
				result.Add(ToDTModelsParsers.DTExerciseParser(exercise));
			}
			return result;
		}

		public async Task AddExerciseAsync(ExerciseDT exerciseDT, int userCreateId)
		{
			var exercise = ToDBModelsParsers.ExerciseParser(exerciseDT);
			await _entityProviderExercise.AddEntityAsync(exercise, userCreateId);
		}

		public async Task<List<ExerciseLangDT>> GetAllExerciseLangsAsync()
		{
			var langs = await _entityProviderExerciseLang.GetAllEntitiesWithIncludeAsync();
			var result = new List<ExerciseLangDT>();
			foreach(var lang in langs)
			{
				result.Add(ToDTModelsParsers.DTExerciseLanguageParser(lang));
			}

			return result;
		}

		public async Task<List<ExerciseCategoryDT>> GetAllExerciseCategoriesAsync()
		{
			var categories = await _entityProviderExerciseCategory.GetAllEntitiesWithIncludeAsync();
			var result = new List<ExerciseCategoryDT>();
			foreach (var category in categories)
			{
				result.Add(ToDTModelsParsers.DTExerciseCategoryParser(category));
			}

			return result;
		}

		public async Task<List<ExercisePlatformDT>> GetAllExercisePlatformsAsync()
		{
			var platforms = await _entityProviderExercisePlatform.GetAllEntitiesWithIncludeAsync();
			var result = new List<ExercisePlatformDT>();
			foreach (var platform in platforms)
			{
				result.Add(ToDTModelsParsers.DTExercisePlatformParser(platform));
			}

			return result;
		}

		public async Task AddNewExerciseLangAsync(ExerciseLangDT exerciseLangDT)
		{
			var exerciseLang = ToDBModelsParsers.ExerciseLangParser(exerciseLangDT);
			await _entityProviderExerciseLang.AddEntityAsync(exerciseLang, 1);
		}

		public async Task AddNewExerciseCategoryAsync(ExerciseCategoryDT exerciseCategoryDT)
		{
			var exerciseCategory = ToDBModelsParsers.ExerciseCategoryParser(exerciseCategoryDT);
			await _entityProviderExerciseCategory.AddEntityAsync(exerciseCategory, 1);
		}

		public async Task AddNewExercisePlatformAsync(ExercisePlatformDT exercisePlatformDT)
		{
			var exercisePlatform = ToDBModelsParsers.ExercisePlatformParser(exercisePlatformDT);
			await _entityProviderExercisePlatform.AddEntityAsync(exercisePlatform, 1);
		}
	}
}
