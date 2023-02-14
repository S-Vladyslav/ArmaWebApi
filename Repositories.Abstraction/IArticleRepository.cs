using Domain;

namespace Repositories.Abstraction
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> GetByAuthorId(int id);
    }
}
