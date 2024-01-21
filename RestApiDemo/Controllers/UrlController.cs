using Microsoft.AspNetCore.Mvc;
using RestApiDemo.Services;

namespace RestApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly ILogger<UrlController> _logger;
        private readonly IUrlService _urlShortenService;

        //Note: when doing Dependency injection for service class, make sure to use the interface , not the class in the parameter here, otherwise error 500 can occur
        public UrlController(IUrlService urlShortenService, ILogger<UrlController> logger)
        {
            _logger = logger;
            this._urlShortenService = urlShortenService;
        }

        [HttpGet("get")]
        public ActionResult<string> GetUrl()
        {
            try
            {
                return Ok(this._urlShortenService.GetUrl());
            }
            catch (FormatException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("encrypt")]
        public ActionResult<string> EncryptUrl([FromBody] string url)
        {
            try
            {
                return Ok(this._urlShortenService.EncryptUrl(url));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
