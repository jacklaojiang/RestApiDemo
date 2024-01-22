using RestApiDemo.Entities;

namespace RestApiDemo.Repos
{
    public interface IUrlRepo
    {

        public Task<IEnumerable<UrlEntity>> GetAll();

        public Task AddUrl(UrlEntity url);

        public Task UpdateUrl(int Id, UrlEntity url);
    }
}
