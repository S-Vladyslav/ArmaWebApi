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
        private IArticleService _articleService;

        public ArticlesToApproveController(IArticleService articleService)
        {
            _articleService = articleService;
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
