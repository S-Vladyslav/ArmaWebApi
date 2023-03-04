namespace Repositories.Abstraction.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }
        IArticleToApproveRepository ArticleToApproveRepository { get; }
        IUserRepository UserRepository { get; }
        ISessionRepository SessionRepository { get; }

        int Complete();
    }
}
