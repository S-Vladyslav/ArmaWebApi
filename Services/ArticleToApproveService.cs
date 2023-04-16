using Configuration;
using Domain;
using Repositories.Abstraction;
using Services.Abstraction;

namespace DataAccess.Services
{
    public class ArticleToApproveService : IArticleToApproveService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICustomConfigurationManager _configurationManager;

        public ArticleToApproveService(IUnitOfWorkFactory unitOfWorkFactory, ICustomConfigurationManager configurationManager)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this._configurationManager = configurationManager;
        }

        public void AddArticleToApprove(ArticleToApprove article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                repo.Add(article);

                var complete = unitOfWork.Complete();
            }
        }

        public ArticleToApprove GetArticleToApprove(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                var entity = repo.Get(id);

                return entity;
            }
        }

        public List<ArticleToApprove> GetAllArticlesToApprove()
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                var entitiesList = repo.GetAll();

                return entitiesList;
            }
        }

        public void RemoveArticleToApprove(ArticleToApprove article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                repo.Remove(article);

                var complete = unitOfWork.Complete();
            }
        }

        public void RemoveArticleToApproveById(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                var article = repo.Get(id);

                repo.Remove(article);

                var complete = unitOfWork.Complete();
            }
        }
    }
}
