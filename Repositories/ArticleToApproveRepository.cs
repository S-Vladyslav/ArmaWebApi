using Domain;
using Repositories.Abstraction;
using Repositories.Context;

namespace Repositories
{
    public class ArticleToApproveRepository : Repository<ArticleToApprove>, IArticleToApproveRepository
    {
        public ArticleToApproveRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}
