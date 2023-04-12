using Domain.Articles;

namespace Repositories.Abstraction
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> GetByAuthorId(int id);

        List<Article> GetPageByAuthorId(int id, int pageSize, int start);
    }
}
