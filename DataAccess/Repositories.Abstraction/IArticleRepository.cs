using Domain;

namespace DataAccess.Repositories.Abstraction
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> GetByAuthorId(int id);
    }
}
