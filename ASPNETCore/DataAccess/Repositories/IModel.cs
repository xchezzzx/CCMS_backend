using ASPNETCore.DataAccess.Models.DBModels;
using System.Data.Entity;

namespace ASPNETCore.DataAccess.Repositories
{
    public interface IGenerateUsers
	{
		Task GenerateUsers();
	}

	public interface IReadUsers
	{
		Task<List<User>> ReadUsers();
	}

	public class UsersStorage : IGenerateUsers, IReadUsers
	{
		private List<User> Users;
		private readonly CCMSContext _dbContext;

		public UsersStorage(CCMSContext dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<List<User>> ReadUsers()
		{
			if (Users == null)
			{
				await GenerateUsers();
			}
			return Users;
		}

		public async Task GenerateUsers()
		{
			Users = await _dbContext.Users.ToListAsync();
		}
	}
}
