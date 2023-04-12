using Domain.Articles;
using Repositories.Abstraction;
using Services.Abstraction;

namespace Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ArticleService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        private string _connectionString = "Data Source=localhost;Initial Catalog=ArmaGuidesDev;Integrated Security=True;Trust Server Certificate=true";

        public Article GetArticle(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                var article = repo.Get(id);

                return article;
            }
        }

        public List<Article> GetArticles(int pageSize, int start)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                var articles = repo.GetPage(pageSize, start);

                return articles;
            }
        }

        public void AddArticle(Article article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                repo.Add(article);

                var complete = unitOfWork.Complete();
            }
        }

        public void RemoveArticle(Article article)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork(_connectionString))
            {
                var repo = unitOfWork.ArticleRepository;

                repo.Remove(article);

                var complete = unitOfWork.Complete();
            }
        }
    }
}
