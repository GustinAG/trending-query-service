using Microsoft.AspNetCore.Mvc;
using Trending.Query.Dal;

namespace Trending.Query.Api.Controllers
{
    [Route("trendings")]
    [ApiController]
    public class TrendingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<TrendingsDto> Get() => ArticleTrendingsDal.GetAll();
    }
}