using DataAccess.Interfaces;
using Domain;

namespace DataAccess.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }

        public List<Article> GetByAuthorId(int id)
        {
            return AppDBContext.Set<Article>().Where(x => x.AuthorId == id).ToList();
        }
    }
}
