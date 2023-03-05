using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace ArmaWebApi.Controllers
{
    [Route("api/articles")]
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
        public IActionResult GetArticleById(int id)
        {
            try
            {
                var article = _articleService.GetArticle(id);

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
    }
}
