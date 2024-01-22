using RestApiDemo.Configs;

using Dapper;
using Microsoft.Data.SqlClient;
using RestApiDemo.Entities;
using System.Data.Common;
using Microsoft.Extensions.Options;
namespace RestApiDemo.Repos
{
    public class UrlRepo : IUrlRepo
    {
        public readonly DbConfig _dbConfig;
        public UrlRepo(IOptions<DbConfig> dbConfig) 
        {
            this._dbConfig = dbConfig.Value;
        }

        public Task EncryptUrl()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UrlEntity>> GetAll()
        {
            using (var connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                await connection.OpenAsync();
                var sql = "select * from UrlMap";
                var result = (await connection.QueryAsync<UrlEntity>(sql));
                return result;
            }
        }

        public async Task AddUrl(UrlEntity url)
        {
            using (var connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                await connection.OpenAsync();
                var sql = @"INSERT INTO UrlMap (Id, OriginalUrl, EncryptedUrl, CreateDate) VALUES (@Id, @OriginalUrl, @EncryptedUrl, @CreateDate);";
                await connection.ExecuteScalarAsync(sql, url);
            }
        }

        public async Task UpdateUrl(int Id, UrlEntity url)
        {
            using (var connection = new SqlConnection(_dbConfig.ConnectionString))
            {
                await connection.OpenAsync();
                var sql = @"UPDATE UrlMap
                SET OriginalUrl = @OriginalUrl,
                    EncryptedUrl = @EncryptedUrl,
                    CreateDate = @CreateDate
                WHERE Id = @Id;";
                await connection.ExecuteAsync(sql, url);
            }
        }
    }
}
