using DataAccess.Context;
using DataAccess.Repositories.Abstraction;
using Domain;

namespace DataAccess.Repositories
{
    public class ArticleToApproveRepository : Repository<ArticleToApprove>, IArticleToApproveRepository
    {
        public ArticleToApproveRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}
