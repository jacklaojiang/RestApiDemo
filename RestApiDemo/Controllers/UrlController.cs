using Microsoft.AspNetCore.Mvc;
using RestApiDemo.Entities;
using RestApiDemo.Services;

namespace RestApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly ILogger<UrlController> _logger;
        private readonly IUrlService _urlService;

        //Note: when doing Dependency injection for service class, make sure to use the interface , not the class in the parameter here, otherwise error 500 can occur
        public UrlController(IUrlService urlShortenService, ILogger<UrlController> logger)
        {
            _logger = logger;
            this._urlService = urlShortenService;
        }

        [HttpGet("GetAllUrls")]
        public async Task<IEnumerable<UrlEntity>> GetUrl()
        {
            try
            {
                return await this._urlService.GetAllUrl();
            }
            catch (FormatException ex) 
            {
                throw ;
            }
        }

        [HttpPost("EncryptUrl")]
        public ActionResult<string> EncryptUrl([FromBody] string url)
        {
            try
            {
                return Ok(this._urlService.EncryptUrl(url));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddUrl")]
        public async Task AddUrl([FromBody] UrlEntity url)
        {
            try
            {
                await _urlService.AddUrl(url);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPut("Update/{id}")]
        public async Task UpdateUrl(int id, [FromBody] UrlEntity url)
        {
            // var result = GetWithId(id)
            // if (result == null) return;

            try
            {
                await _urlService.UpdateUrl(id, url);
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
