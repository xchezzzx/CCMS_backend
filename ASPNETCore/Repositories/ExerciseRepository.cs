using ASPNETCore.Constants;
using ASPNETCore.Helpers;
using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using System.Data.Entity;

namespace ASPNETCore.Repositories
{
    public class ExerciseRepository : IExercise
    {
        private readonly CCMSContext _dbContext;

        public ExerciseRepository(CCMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Exercise> GetAllExercises => _dbContext.Tasks
            .Include(e => e.CreateUser)
            .Include(e => e.UpdateUser)
            .Include(e => e.Status)
            .Include(e => e.Lang)
            .Include(e => e.Category)
            .Include(e => e.Platform)
            .ToList();


        public List<Exercise> GetAllActiveExercises => _dbContext.Tasks
            .Where(e => e.StatusId == (int)EntityStatuses.active)
            .Include(e => e.CreateUser)
            .Include(e => e.UpdateUser)
            .Include(e => e.Status)
            .Include(e => e.Lang)
            .Include(e => e.Category)
            .Include(e => e.Platform)
            .ToList();

        public void AddNewExercise(Exercise exercise, int createUserId)
        {
            FillEntityHelper.CreateEntity(ref exercise, createUserId);
            _dbContext.Tasks.Add(exercise);
            _dbContext.SaveChanges();
        }

        public void DeleteExercise(Exercise exercise, int updateUserId)
        {
            FillEntityHelper.DeleteEntity(ref exercise, updateUserId);
            _dbContext.Tasks.Update(exercise);
            _dbContext.SaveChanges();
        }

        public Exercise GetExerciseById(int id)
        {
            return _dbContext.Tasks
            .Where(e => e.StatusId == (int)EntityStatuses.active && e.Id == id)
            .Include(e => e.CreateUser)
            .Include(e => e.UpdateUser)
            .Include(e => e.Status)
            .Include(e => e.Lang)
            .Include(e => e.Category)
            .Include(e => e.Platform)
            .FirstOrDefault();
        }

        public List<Exercise> GetExercisesByState(int exerciseStateId)
        {
            throw new NotImplementedException();
        }

        public void UpdateExercise(Exercise exercise, int updateUserId)
        {
            FillEntityHelper.UpdateEntity(ref exercise, updateUserId);
            _dbContext.Tasks.Update(exercise);
            _dbContext.SaveChanges();
        }
    }
}
