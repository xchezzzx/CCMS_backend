using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using System.Data.Entity;


namespace CCMS.Repositories
{
    //public class UserRepository : IUser
    //{

    //    private readonly CCMSContext _modelsContext;

    //    public UserRepository(CCMSContext modelsContext)
    //    {
    //        _modelsContext = modelsContext;
    //    }

    //    public IEnumerable<User> GetUsers => _modelsContext.Users.Include(c => c!.UserRole).ToList();
    //    public IEnumerable<User> GetActiveUsers => _modelsContext.Users.Include(c => c.UserRole).Include(u => u.UserStatus).Include(u => u.UserCreate).Include(u => u.UserUpdate);

    //    public User GetUser(int id) => _modelsContext.Users.First(u => u.Id == id);
    //}
}
