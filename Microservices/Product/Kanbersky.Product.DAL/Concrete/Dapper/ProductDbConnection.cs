using Kanbersky.Ocelot.Core.Results.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace Kanbersky.Product.DAL.Concrete.Dapper
{
    public class ProductDbConnection : IProductDbConnection
    {
        private readonly string _connectionString;
        public IConfiguration _configuration { get; }

        public ProductDbConnection(IConfiguration configuration)
        {
            _configuration = configuration;

            if (string.IsNullOrEmpty(_configuration["ConnectionStrings:DefaultConnection"]))
                throw new NotFoundException("No Connection string value");

            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        }

        public DbConnection CreateDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
