using Microsoft.Extensions.Options;
using RestApiDemo.Configs;

namespace RestApiDemo.Services
{
    public class UrlService : IUrlService
    {
        private readonly UrlConfig _urlConfig;
        public UrlService(IOptions<UrlConfig> config)
        {
            this._urlConfig = config.Value;
        }

        public string GetUrl()
        {
            return $"Url Shorten service is called, baseUrl = {_urlConfig.BaseUrl}";
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
    }
}
