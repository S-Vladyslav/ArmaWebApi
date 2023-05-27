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

        public async Task AddArticleToApproveAsync(ArticleToApprove article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                await repo.AddAsync(article);

                var complete = await unitOfWork.CompleteAsync();
            }
        }

        public async Task<ArticleToApprove> GetArticleToApproveAsync(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                var entity = await repo.GetAsync(id);

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

        public async Task RemoveArticleToApproveAsync(ArticleToApprove article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                repo.Remove(article);

                var complete = await unitOfWork.CompleteAsync();
            }
        }

        public async Task RemoveArticleToApproveByIdAsync(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleToApproveRepository;

                var article = await repo.GetAsync(id);

                repo.Remove(article);

                var complete = await unitOfWork.CompleteAsync();
            }
        }
    }
}
