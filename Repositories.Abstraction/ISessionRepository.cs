using Domain;

namespace Repositories.Abstraction
{
    public interface ISessionRepository : IRepository<Session>
    {
        Session GetSessionByUserId(int userId);

        Session GetSessionByToken(string token);
    }
}
