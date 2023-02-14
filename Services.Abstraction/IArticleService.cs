using Domain;

namespace Services.Abstraction
{
    public interface IArticleService
    {
        ArticleToApprove GetArticleToApprove(int id);

        void AddArticleToApprove(ArticleToApprove article);
    }
}
