using Domain;
using Microsoft.AspNetCore.Mvc;
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

                var article = _articleToApproveService.GetArticleToApprove(id);

                if (article == null)
                {
                    return StatusCode(204, $"No article to approve with id {id}");
                }

                return StatusCode(200, article);
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

        [HttpGet("getallarticles")]
        public IActionResult GetAllArticlesToApprove(string token)
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

                var articles = _articleToApproveService.GetAllArticlesToApprove();

                if (articles == null)
                {
                    return StatusCode(204, $"No articles to approve");
                }

                return StatusCode(200, articles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("approve")]
        public IActionResult ApproveArticleToApprove(ArticleId id, string token)
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

                var article = _articleToApproveService.GetArticleToApprove(id.Id);

                var newArticle = new Article
                {
                    Title = article.Title,
                    IconUrl = article.IconUrl,
                    ArticleContent = article.ArticleContent,
                    Category = article.Category,
                    AuthorId = article.AuthorId,
                    PublishDate = DateTime.Today.Date.ToString()
                };

                _articleService.AddArticle(newArticle);

                _articleToApproveService.RemoveArticleToApproveById(id.Id);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("reject")]
        public IActionResult RejectArticleToApprove(ArticleId id, string token)
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

                _articleToApproveService.RemoveArticleToApproveById(id.Id);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
