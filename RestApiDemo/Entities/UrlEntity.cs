namespace RestApiDemo.Entities
{
    public class UrlEntity
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string? EncryptedUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
