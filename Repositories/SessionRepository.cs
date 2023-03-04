using Domain;
using Repositories.Abstraction;
using Repositories.Context;

namespace Repositories
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }

        public Session GetSessionByUserId(int userId)
        {
            return AppDBContext.Set<Session>().Where(x => x.UserId == userId).First();
        }

        public Session GetSessionByToken(string token)
        {
            return AppDBContext.Set<Session>().Where(x => x.Token == token).First();
        }
    }
}
