using Configuration;
using Domain.Articles;
using Repositories.Abstraction;
using Services.Abstraction;

namespace Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICustomConfigurationManager _configurationManager;

        public ArticleService(IUnitOfWorkFactory unitOfWorkFactory, ICustomConfigurationManager configurationManager)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this._configurationManager = configurationManager;
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                var article = await repo.GetAsync(id);

                return article;
            }
        }

        public List<Article> GetArticles(int pageSize, int start)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                var articles = repo.GetPage(pageSize, start);

                return articles;
            }
        }

        public async Task AddArticleAsync(Article article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                await repo.AddAsync(article);

                var complete = await unitOfWork.CompleteAsync();
            }
        }

        public async Task RemoveArticleAsync(Article article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                repo.Remove(article);

                var complete = await unitOfWork.CompleteAsync();
            }
        }
    }
}
