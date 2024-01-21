namespace RestApiDemo.Services
{
    public interface IUrlService
    {
        public string GetUrl();
        public string EncryptUrl(string url);
    }
}
