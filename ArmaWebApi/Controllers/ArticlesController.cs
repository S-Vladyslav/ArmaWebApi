using Domain.Articles;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace ArmaWebApi.Controllers
{
    [Route("api/article")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ISessionService _sessionService;

        public ArticlesController(IArticleService articleService, ISessionService sessionService)
        {
            _articleService = articleService;
            _sessionService = sessionService;
        }

        [HttpGet("getarticle")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            try
            {
                var article = await _articleService.GetArticleAsync(id);

                if (article == null)
                {
                    return StatusCode(204, $"No article with id {id}");
                }

                return StatusCode(200, article);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getarticles")]
        public IActionResult GetArticles(int start = 0, int count = 10)
        {
            try
            {
                var articles = _articleService.GetArticles(count, start);

                if (articles == null)
                {
                    return StatusCode(204, $"No articles");
                }

                var articlesPreview = new List<ArticlePreview>();
                foreach (var article in articles)
                {
                    articlesPreview.Add(new ArticlePreview
                    {
                        Id = article.Id,
                        Title = article.Title,
                        IconUrl = article.IconUrl
                    });
                }

                return StatusCode(200, articlesPreview);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
