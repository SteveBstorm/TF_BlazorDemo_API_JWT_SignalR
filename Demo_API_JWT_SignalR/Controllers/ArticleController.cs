using Demo_API_JWT_SignalR.Hubs;
using Demo_API_JWT_SignalR.Models;
using Demo_API_JWT_SignalR.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API_JWT_SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;
        private readonly ArticleHub _hub;

        public ArticleController(ArticleService articleService, ArticleHub hub)
        {
            _articleService = articleService;
            _hub = hub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_articleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_articleService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Article a)
        {
            _articleService.Add(a);
            await _hub.NewArticle();
            return Ok();
        }
    }
}
