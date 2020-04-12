using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Trending.Query.Api.Controllers
{
    /// <summary>
    /// API root level controller.
    /// </summary>
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        /// <summary>
        /// Gets general product info - including version.
        /// </summary>
        /// <returns>Product info.</returns>
        [HttpGet]
        public string Get()
        {
            var assembly = GetType().Assembly;
            var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            var name = versionInfo.ProductName;
            var version = assembly.GetName().Version.ToString();
            var copyright = versionInfo.LegalCopyright;

            return $"{name} v{version} - {copyright}";
        }
    }
}