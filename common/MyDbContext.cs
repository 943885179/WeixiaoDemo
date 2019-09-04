using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeixiaoDemo.common
{
    public interface IMyDbContext
    {
        string GetConnection();
    }
    public class MyDbContext : IMyDbContext
    {
        public string GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
