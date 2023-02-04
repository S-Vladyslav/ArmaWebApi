using Domain;

namespace DataAccess.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> GetByAuthorId(int id);
    }
}
