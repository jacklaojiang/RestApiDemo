using Microsoft.Extensions.Options;
using Moq;
using RestApiDemo.Configs;
using RestApiDemo.Entities;
using RestApiDemo.Repos;
using RestApiDemo.Services;
using Xunit;

namespace AnotherUnitTest
{
    public class UrlServiceUnitTests
    {
        private IUrlService sut;
        [Fact]
        public async Task UrlService_ReturnAllUrls_Success()
        {
            var urlConfigMock = new Mock<IOptions<UrlConfig>>();
            var urlRepoMock = new Mock<IUrlRepo>();

            var expected = new List<UrlEntity>
            {
                new UrlEntity
                {
                    Id = 1,
                    OriginalUrl = "test1",
                    EncryptedUrl = "test1",
                    CreateDate = DateTime.Now
                }
            };

            // to mock the return value of getAll
            urlRepoMock.Setup(repo => repo.GetAll()).ReturnsAsync(expected);

            this.sut = new UrlService(urlConfigMock.Object, urlRepoMock.Object);

            var result = await this.sut.GetAllUrl();

            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }
    }
}