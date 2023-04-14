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

        public Article GetArticle(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                var article = repo.Get(id);

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

        public void AddArticle(Article article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                repo.Add(article);

                var complete = unitOfWork.Complete();
            }
        }

        public void RemoveArticle(Article article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_configurationManager.DBConnectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                repo.Remove(article);

                var complete = unitOfWork.Complete();
            }
        }
    }
}
