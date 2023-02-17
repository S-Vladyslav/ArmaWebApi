using Domain;

namespace Services.Abstraction
{
    public interface IArticleToApproveService
    {
        ArticleToApprove GetArticleToApprove(int id);

        void AddArticleToApprove(ArticleToApprove article);

        List<ArticleToApprove> GetAllArticlesToApprove();

        void RemoveArticleToApproveById(int id);

        void RemoveArticleToApprove(ArticleToApprove article);
    }
}
