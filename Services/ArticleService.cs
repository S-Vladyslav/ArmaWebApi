using Domain;
using Repositories.Abstraction;
using Services.Abstraction;

namespace DataAccess.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ArticleService(IUnitOfWorkFactory unitOfWorkFactory)//IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;//unitOfWorkFactory;
        }

        private string _connectionString = "Data Source=localhost;Initial Catalog=ArmaGuidesDev;Integrated Security=True;Trust Server Certificate=true";

        public void AddArticleToApprove(ArticleToApprove article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                repo.Add(article);

                var complete = unitOfWork.Complete();
            }
        }

        public ArticleToApprove GetArticleToApprove(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                var entity = repo.Get(id);

                return entity;
            }
        }
    }
}
