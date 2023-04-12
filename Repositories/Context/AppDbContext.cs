using Domain;
using Domain.Articles;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context
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
        DbSet<Session> Sessions { get; set; }
    }
}
