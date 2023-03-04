using Domain.Users;

namespace Repositories.Abstraction
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByName(string username);

        User GetUserByEmail(string email);
    }
}
