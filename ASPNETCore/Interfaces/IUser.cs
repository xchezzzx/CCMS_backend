using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Interfaces
{
    public interface IUser
    {
        List<User> GetUsers { get; }
        List<User> GetActiveUsers { get; }
        User GetUserById(int userId);
        void AddNewUser(User user, int userCreateId);
        void UpdateUser(User user, int userUpdateId);
        void DeleteUser(User user, int userUpdateId);

    }
}
