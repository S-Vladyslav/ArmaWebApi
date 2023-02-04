using DataAccess.Repositories.Abstraction;

namespace DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }
        IArticleToApproveRepository ArticleToApproveRepository { get; }

        int Complete();
    }
}
