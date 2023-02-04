using DataAccess.Context;
using DataAccess.Repositories.Abstraction;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArticleToApproveRepository : Repository<ArticleToApprove>, IArticleToApproveRepository
    {
        public ArticleToApproveRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}
