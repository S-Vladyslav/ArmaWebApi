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

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("getarticle")]
        public Article GetArticleById(int id)
        {
            return _articleService.GetArticle(id);
        }
    }
}
