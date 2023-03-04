using Domain.Users;
using Repositories.Abstraction;
using Repositories.Context;

namespace Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }

        public User GetUserByName(string username)
        {
            return AppDBContext.Set<User>().Where(x => x.UserName == username).First();
        }

        public User GetUserByEmail(string email)
        {
            return AppDBContext.Set<User>().Where(x => x.Email == email).First();
        }
    }
}
