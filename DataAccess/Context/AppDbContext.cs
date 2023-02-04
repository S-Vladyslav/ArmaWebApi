using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        DbSet<Article> Articles { get; set; }
        DbSet<ArticleToApprove> ArticlesToApprove { get; set; }
        DbSet<User> Users { get; set; }
    }
}
