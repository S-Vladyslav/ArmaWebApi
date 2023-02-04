using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        DbSet<Article> Articles;
        DbSet<ArticleToApprove> ArticlesToApprove;
        DbSet<User> Users;
    }
}
