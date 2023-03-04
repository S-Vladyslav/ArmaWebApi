using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Abstraction;

namespace ArmaWebApi.Controllers
{
    [Route("api/articletoapprove")]
    [ApiController]
    public class ArticlesToApproveController : ControllerBase
    {
        private readonly IArticleToApproveService _articleToApproveService;
        private readonly IArticleService _articleService;

        public ArticlesToApproveController(IArticleToApproveService articleToApproveService, IArticleService articleService)
        {
            _articleToApproveService = articleToApproveService;
            _articleService = articleService;
        }

        [HttpGet("{id}")]
        public string GetArticleToApprove(int id)
        {
            return JsonConvert.SerializeObject(_articleToApproveService.GetArticleToApprove(id));
        }

        [HttpPost("add")]
        public void AddArticleToApprove(ArticleToApprove value)
        {
            _articleToApproveService.AddArticleToApprove(value);
        }

        [HttpGet("allarticles")]
        public string GetAllArticlesToApprove()
        {
            return JsonConvert.SerializeObject(_articleToApproveService.GetAllArticlesToApprove());
        }

        [HttpPost("approve")]
        public void ApproveArticleToApprove(ArticleId id)
        {
            var article = _articleToApproveService.GetArticleToApprove(id.Id);

            var newArticle = new Article {
                Title = article.Title,
                IconUrl = article.IconUrl,
                ArticleContent = article.ArticleContent,
                Category = article.Category,
                AuthorId = article.AuthorId,
                PublishDate = DateTime.Today.ToString()
            };

            _articleService.AddArticle(newArticle);

            _articleToApproveService.RemoveArticleToApproveById(id.Id);
        }

        [HttpDelete("reject")]
        public void RejectArticleToApprove(ArticleId id)
        {
            _articleToApproveService.RemoveArticleToApproveById(id.Id);
        }
    }
}
