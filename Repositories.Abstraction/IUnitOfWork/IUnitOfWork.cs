namespace Repositories.Abstraction.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }
        IArticleToApproveRepository ArticleToApproveRepository { get; }

        int Complete();
    }
}
