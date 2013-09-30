using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperExtensions;
using WorldWideWat.IffyLink.Service.Models;

namespace WorldWideWat.IffyLink.Service
{
    public interface ILinkRepository
    {
        LinkInfo GetLinkInfo(string alias);

        void CreateLink(string link, string alias, DateTimeOffset expiration);
    }

    public class LinkRepository : ILinkRepository
    {
        private readonly string _connectionString;

        public LinkRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LinkInfo GetLinkInfo(string alias)
        {
            const string Query =
                "SELECT * FROM LinkAliases A INNER JOIN Links L ON A.LinkId = L.Id WHERE A.Alias = @alias";

            using (var connection = GetOpenConnection())
            {
                return connection.Query<LinkInfo>(Query, new {alias}).SingleOrDefault();
            }
        }

        public void CreateLink(string link, string alias, DateTimeOffset expiration)
        {
            const string GetLinkQuery = "SELECT Id FROM Links WHERE Url = @link";

            using (var connection = GetOpenConnection())
            using (var transaction = connection.BeginTransaction())
            {
                var existingLink = connection.Query<long?>(GetLinkQuery, new {link}, transaction).SingleOrDefault();

                if (!existingLink.HasValue)
                {
                    existingLink = connection.Insert(new Link {Url = link, Created = DateTimeOffset.UtcNow}, transaction);
                }

                connection.Insert(
                    new LinkAlias
                    {
                        Alias = alias,
                        LinkId = existingLink.Value,
                        Expires = expiration,
                        Created = DateTimeOffset.UtcNow
                    }, transaction);

                transaction.Commit();
            }
        }

        private IDbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection;
        }
    }
}