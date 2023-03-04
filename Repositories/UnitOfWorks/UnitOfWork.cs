using Repositories.Abstraction;
using Repositories.Abstraction.UnitOfWorks;
using Repositories.Context;

namespace Repositories.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _appDbContext;

        public IArticleRepository ArticleRepository { get; private set; }
        public IArticleToApproveRepository ArticleToApproveRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public ISessionRepository SessionRepository { get; private set; }

        public UnitOfWork(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;

            ArticleRepository = new ArticleRepository(_appDbContext);
            ArticleToApproveRepository = new ArticleToApproveRepository(_appDbContext);
            UserRepository  = new UserRepository(_appDbContext);
        }

        public int Complete()
        {
            return _appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
