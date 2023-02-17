using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArmaWebApi.Controllers
{
    [Route("api/articletoapprove")]
    [ApiController]
    public class ArticlesToApproveController : ControllerBase
    {
        private IArticleToApproveService _articleToApproveService;
        private IArticleService _articleService;

        public ArticlesToApproveController(IArticleToApproveService articleToApproveService, IArticleService articleService)
        {
            _articleToApproveService = articleToApproveService;
            _articleService = articleService;
        }

        [HttpGet("article/{id}")]
        public string GetArticle(int id)
        {
            return JsonConvert.SerializeObject(_articleToApproveService.GetArticleToApprove(id));
        }

        [HttpPost("add")]
        public void AddArticle( ArticleToApprove value)
        {
            _articleToApproveService.AddArticleToApprove(value);
        }

        [HttpGet("allarticles")]
        public string GetAllArticles()
        {
            return JsonConvert.SerializeObject(_articleToApproveService.GetAllArticlesToApprove());
        }

        [HttpPost("approve")]
        public void ApproveArticle(ArticleId id)
        {
            var article = _articleToApproveService.GetArticleToApprove(id.Id);

            var newArticle = new Article { 
                Title = article.Title,
                IconUrl = article.IconUrl,
                ArticleContent = article.ArticleContent,
                Category = article.Category,
                AuthorId = article.AuthorId,
                PublishDate = "today"
            };

            _articleService.AddArticle(newArticle);

            _articleToApproveService.RemoveArticleToApproveById(id.Id);
        }
    }
}
