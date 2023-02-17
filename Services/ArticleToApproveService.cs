using Domain;
using Repositories.Abstraction;
using Services.Abstraction;

namespace DataAccess.Services
{
    public class ArticleToApproveService : IArticleToApproveService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ArticleToApproveService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
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

        public List<ArticleToApprove> GetAllArticlesToApprove()
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                var entitiesList = repo.GetAll();

                return entitiesList;
            }
        }

        public void RemoveArticleToApprove(ArticleToApprove article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                repo.Remove(article);

                var complete = unitOfWork.Complete();
            }
        }

        public void RemoveArticleToApproveById(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                var article = repo.Get(id);

                repo.Remove(article);

                var complete = unitOfWork.Complete();
            }
        }
    }
}
