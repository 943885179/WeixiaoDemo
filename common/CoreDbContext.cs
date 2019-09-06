using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeixiaoDemo.common
{ public class Person
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(3)]
        public int Age { get; set; }
    }
    public class CoreDbContext:DbContext
    {
        public virtual DbSet<Person> Person { get; set; } //创建实体类添加Context中

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //MySQL.Data.EntityFrameworkCore.Extensions
                //optionsBuilder.UseMySQL(@"server=localhost;uid=YourUserId;pwd=YourPassword;
                //    port=3306;database=DbName;sslmode=Preferred;");
            }
        }
    }
}
