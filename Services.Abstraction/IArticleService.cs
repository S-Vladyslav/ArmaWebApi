using Domain.Articles;

namespace Services.Abstraction
{
    public interface IArticleService
    {
        Task<Article> GetArticleAsync(int id);

        Task AddArticleAsync(Article article);

        Task RemoveArticleAsync(Article article);

        List<Article> GetArticles(int pageSize, int start);
    }
}
