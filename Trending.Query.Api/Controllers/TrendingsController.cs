using Microsoft.AspNetCore.Mvc;

namespace Trending.Query.Api.Controllers
{
    [Route("trendings")]
    [ApiController]
    public class TrendingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<TrendingsDto> Get()
        {
            var dto = new TrendingsDto { ShortTrendingArticleIds = new[] { 1, 3 }, LongTrendingArticleIds = new[] { 2 } };
            return dto;
        }
    }
}