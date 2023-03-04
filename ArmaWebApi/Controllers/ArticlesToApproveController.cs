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
        private readonly ISessionService _sessionService;
        private readonly IUserService _userService;

        public ArticlesToApproveController(IArticleToApproveService articleToApproveService, IArticleService articleService, ISessionService sessionService, IUserService userService)
        {
            _articleToApproveService = articleToApproveService;
            _articleService = articleService;
            _sessionService = sessionService;
            _userService = userService;
        }

        [HttpGet("getarticle")]
        public IActionResult GetArticleToApprove(int id, string token)
        {
            try
            {
                var session = _sessionService.GetSessionByToken(token);
                var user = _userService.GetUserById(session.UserId);
                if (session == null || user == null)
                {
                    return StatusCode(401);
                }
                else if (user.UserRole < (int)UserRoles.Moderator)
                {
                    return StatusCode(403);
                }

                var content = _articleToApproveService.GetArticleToApprove(id);

                if (content == null)
                {
                    return StatusCode(204, $"No article to approve with id {id}");
                }
                return StatusCode(200, content);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult AddArticleToApprove(ArticleToApprove value, string token)
        {
            try
            {
                var session = _sessionService.GetSessionByToken(token);
                var user = _userService.GetUserById(session.UserId);
                if (session == null || user == null)
                {
                    return StatusCode(401);
                }

                _articleToApproveService.AddArticleToApprove(value);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
