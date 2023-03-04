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
    }
}
