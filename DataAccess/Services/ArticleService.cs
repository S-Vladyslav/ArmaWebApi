using Domain;

namespace DataAccess.Services
{
    public class ArticleService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ArticleService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void AddArticleToApprove(ArticleToApprove article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork("Data Source=localhost;Initial Catalog=ArmaGuidesDev;Integrated Security=True"))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                repo.Add(article);
            }
        }
    }
}
