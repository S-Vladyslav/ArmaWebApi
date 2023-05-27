using Domain;

namespace Services.Abstraction
{
    public interface IArticleToApproveService
    {
        Task <ArticleToApprove> GetArticleToApproveAsync(int id);

        Task AddArticleToApproveAsync(ArticleToApprove article);

        List<ArticleToApprove> GetAllArticlesToApprove();

        Task RemoveArticleToApproveByIdAsync(int id);

        Task RemoveArticleToApproveAsync(ArticleToApprove article);
    }
}
