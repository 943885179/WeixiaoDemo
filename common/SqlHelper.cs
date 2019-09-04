using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WeixiaoDemo.common
{
    public interface ISqlHelper
    {
        string GetSqlConnection();
    }
    public class SqlHelper : ISqlHelper
    {
        private IConfiguration _configuration;
        private static IDbConnection connection;
        public SqlHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public string GetSqlConnection()
        {
            return _configuration.GetConnectionString("SQLConnection");
        }
    }
}
