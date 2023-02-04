using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Repositories.Abstraction;

namespace DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _appDbContext;

        public IArticleRepository ArticleRepository { get; private set; }
        public IArticleToApproveRepository ArticleToApproveRepository { get; private set; }

        public UnitOfWork(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;

            ArticleRepository = new ArticleRepository(_appDbContext);
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
