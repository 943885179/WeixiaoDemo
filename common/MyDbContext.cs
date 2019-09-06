using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WeixiaoDemo.common
{
    public class MyDbContext
    {
        public static IDbConnection Connection;
        public MyDbContext(string configString)
        {
            if (configString.ToLower().Contains("charset") || configString.ToLower().Contains("port"))
            {
                Connection = new MySqlConnection(configString);
            }
            else
            {

                Connection = new SqlConnection(configString);
            }
        }
    }
}
