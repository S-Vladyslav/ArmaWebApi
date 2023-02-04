using DataAccess.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArmaWebApi.Controllers
{
    [Route("api/articletoapprove")]
    [ApiController]
    public class ArticlesToApproveController : ControllerBase
    {
        private ArticleService _articleService;

        public ArticlesToApproveController()
        {
            _articleService = new ArticleService();
        }

        // GET api/<ArticlesToApproveController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(_articleService.GetArticleToApprove(id));
        }

        // POST api/<ArticlesToApproveController>
        [HttpPost]
        public void Post( ArticleToApprove value)
        {
           _articleService.AddArticleToApprove(value);
        }
    }
}
