using Domain;
using Domain.Articles;
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
        public async Task<IActionResult> GetArticleToApprove(int id, string token)
        {
            try
            {
                var session = _sessionService.GetSessionByToken(token);
                var user = await _userService.GetUserByIdAsync(session.UserId);
                if (session == null || user == null)
                {
                    return StatusCode(401);
                }
                else if (user.UserRole < (int)UserRoles.Moderator)
                {
                    return StatusCode(403);
                }

                var article = await _articleToApproveService.GetArticleToApproveAsync(id);

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
        public async Task<IActionResult> AddArticleToApprove(ArticleToApprove value, string token)
        {
            try
            {
                var session = _sessionService.GetSessionByToken(token);
                var user = await _userService.GetUserByIdAsync(session.UserId);
                if (session == null || user == null)
                {
                    return StatusCode(401);
                }

                await _articleToApproveService.AddArticleToApproveAsync(value);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getallarticles")]
        public async Task<IActionResult> GetAllArticlesToApprove(string token, int start = 0, int count = 5)
        {
            try
            {
                var session = _sessionService.GetSessionByToken(token);
                var user = await _userService.GetUserByIdAsync(session.UserId);
                if (session == null || user == null)
                {
                    return StatusCode(401);
                }
                else if (user.UserRole < (int)UserRoles.Moderator)
                {
                    return StatusCode(403);
                }

                var article = _articleService.GetArticles(count, start);

                if (article == null)
                {
                    return StatusCode(204, $"No articles to approve");
                }

                return StatusCode(200, article);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("approve")]
        public async Task<IActionResult> ApproveArticleToApprove(ArticleId id, string token)
        {
            try
            {
                var session = _sessionService.GetSessionByToken(token);
                var user = await _userService.GetUserByIdAsync(session.UserId);
                if (session == null || user == null)
                {
                    return StatusCode(401);
                }
                else if (user.UserRole < (int)UserRoles.Moderator)
                {
                    return StatusCode(403);
                }

                var article = await _articleToApproveService.GetArticleToApproveAsync(id.Id);

                var newArticle = new Article
                {
                    Title = article.Title,
                    IconUrl = article.IconUrl,
                    ArticleContent = article.ArticleContent,
                    Category = article.Category,
                    AuthorId = article.AuthorId,
                    PublishDate = DateTime.Today.Date.ToString()
                };

                await _articleService.AddArticleAsync(newArticle);

                await _articleToApproveService.RemoveArticleToApproveByIdAsync(id.Id);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("reject")]
        public async Task<IActionResult> RejectArticleToApprove(ArticleId id, string token)
        {
            try
            {
                var session = _sessionService.GetSessionByToken(token);
                var user = await _userService.GetUserByIdAsync(session.UserId);
                if (session == null || user == null)
                {
                    return StatusCode(401);
                }
                else if (user.UserRole < (int)UserRoles.Moderator)
                {
                    return StatusCode(403);
                }

                await _articleToApproveService.RemoveArticleToApproveByIdAsync(id.Id);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
