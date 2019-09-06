using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
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
        IDbConnection GetConnection();
    }
    public class SqlHelper : ISqlHelper
    {
        private IConfiguration _configuration;
        private static IDbConnection connection;
        public SqlHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            var configString = _configuration.GetConnectionString("Default");
            if (configString.ToLower().Contains("charset") || configString.ToLower().Contains("port"))
            {
                connection = new MySqlConnection(configString);
            }
            else
            {

                connection = new SqlConnection(configString);
            }
        }
        public IDbConnection GetConnection()
        {
            return connection;
        }

        //public int Insert()
        //{
           
        //    var reslut=  connection.Execute("Insert into Persons values (@LastName, @FirstName, @Address,@City)",
        //                      new { LastName = "jack", FirstName = "Man", Address = "上海", City="测试" });
        //    return 1;
        //}
        //public IEnumerable<dynamic> Query()
        //{
        //    var x = connection.Query<User>("select * from user where a=@a", new { a = "123" });
        //    x = connection.Query<User>("select * from user where a=@a", new User { a = "123" });
        //    return connection.Query("select * from user");
        //}

    }
    public class User
    {
        public string a { get; set; }
    }
}
