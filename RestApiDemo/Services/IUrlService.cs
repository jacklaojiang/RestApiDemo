using RestApiDemo.Entities;

namespace RestApiDemo.Services
{
    public interface IUrlService
    {
        public Task<IEnumerable<UrlEntity>> GetAllUrl();
        public string EncryptUrl(string url);

        public Task AddUrl(UrlEntity url);

        public Task UpdateUrl(int id, UrlEntity url);

        //public Task DeleteUrl(int id);
    }
}
