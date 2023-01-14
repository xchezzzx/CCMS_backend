using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.DataAccess.Repositories;
using ASPNETCore.Helpers;
using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.ExercisesManager
{
	public class ExercisesManager : IExercisesManager
	{
		private readonly IEntityRepository<Exercise> _entityRepository;

		public ExercisesManager(IEntityRepository<Exercise> entityRepository)
		{
			_entityRepository = entityRepository;
		}

		public async Task<List<ExerciseDT>> GetAllExercisesAsync()
		{
			var exercises = await _entityRepository.GetAllEntitiesWithIncludeAsync(c => c.CreateUser, e => e.UpdateUser, e => e.Lang, e => e.Platform, e => e.Category);

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
			await _entityRepository.AddEntityAsync(exercise, userCreateId);
		}
	}
}
