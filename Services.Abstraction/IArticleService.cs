using Domain;

namespace Services.Abstraction
{
    public interface IArticleService
    {
        Article GetArticle(int id);

        void AddArticle(Article article);

        void RemoveArticle(Article article);
    }
}
