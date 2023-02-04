using DataAccess.Interfaces;

namespace DataAccess
{
    public interface IUnitOfWork
    {
        IArticleRepository ArticleRepository { get; }

        int Complete();
    }
}
