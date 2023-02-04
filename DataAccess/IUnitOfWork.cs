using DataAccess.Interfaces;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }

        int Complete();
    }
}
