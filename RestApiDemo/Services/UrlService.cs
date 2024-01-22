using Microsoft.Extensions.Options;
using RestApiDemo.Configs;
using RestApiDemo.Entities;
using RestApiDemo.Repos;

namespace RestApiDemo.Services
{
    public class UrlService : IUrlService
    {
        private readonly UrlConfig _urlConfig;
        private readonly IUrlRepo _urlRepo;
        public UrlService(IOptions<UrlConfig> config, IUrlRepo urlRepo)
        {
            this._urlConfig = config.Value;
            this._urlRepo = urlRepo;
        }

        public async Task<IEnumerable<UrlEntity>> GetAllUrl()
        {
            var result =  await _urlRepo.GetAll();
            return result;
        }

        public string EncryptUrl(string url) 
        {
            // change the first letter to *
            if (string.IsNullOrEmpty(url)) 
            { return url; }

            var charStr = url.ToCharArray();
            charStr[0] = '*';
            return new string (charStr);
        }

        public async Task AddUrl(UrlEntity url)
        {
            var result = await _urlRepo.GetAll();
            var id = result.Count() + 1;

            url.Id = id;

            await _urlRepo.AddUrl(url);
        }

        public async Task UpdateUrl(int id, UrlEntity url)
        {
            await _urlRepo.UpdateUrl(id, url);
        }
    }
}
