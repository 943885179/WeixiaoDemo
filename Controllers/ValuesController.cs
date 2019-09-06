using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeixiaoDemo.common;
using Dapper;
using System.Data;
using System.Transactions;
using Dapper.Contrib.Extensions;
using Z.Dapper.Plus;

namespace WeixiaoDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ISqlHelper helper;
        private static IDbConnection sdb;
        public ValuesController(ISqlHelper db)
        {
            this.helper = db;
            sdb = helper.GetConnection();
        }
        private static IDbConnection mdb = MyDbContext.Connection;
        // GET api/values
        [HttpGet]
        public object Get()
        {
            //查询
            // var xx = mdb.Query("select * from user").ToList();
            // var tt = sdb.Query("select * from user").ToList();
            //var tts = sdb.Query("select * from user").Where(o=>o.a=="4").FirstOrDefault();
            //后面都以mdb为例，
            //var a1 = mdb.Query<User>("select * from user where a=@a", new { a = "123" });
            //var a2 = mdb.Query<User>("select * from user where a=@a", new User { a = "123" });
            //var a3 = mdb.Execute("insert into user(a) values(@a)", new User { a = "4" });
            //var a4 = mdb.Execute("insert into user(a) values(@a)", new[] { new { a = "5" },new { a = "6" } });
            //var a5 = mdb.Execute("update user set a=12 where a=@a", new { a = "123" });
            //var a6 = mdb.Execute("update user set a=12 where a=@a", new[] { new { a = "5" }, new { a = "6" } });(备注，这个是主键唯一不能同时修改否则报错的)
            // var a7 = mdb.Execute("DELETE FROM user where a=@a", new { a = "12" });
            //var a8 = mdb.Execute("DELETE FROM user where a=@a", new[] { new User { a = "5" }, new User { a = "6" } });
            //一对一查询
            // var a9 = mdb.Query("select * from Person,Depatment where Person.DId=Depatment.Id");

            // var a10 = mdb.Query<Person,Depatment,Person>("select * from Person,Depatment where Person.DId=Depatment.Id",(m,n)=> {m.Depatment = n;return m;});
            //一对多（这个有待研究）
            //var orderDictionary = new Dictionary<int, Depatment>();
            //var a12 = mdb.Query<Depatment, Person, Depatment>("select * from Depatment,Person where Person.DId=Depatment.Id",
            //    (m, n) => {
            //        Depatment dep;
            //        //dep.Persons = new List<Person>();


            //        if (!orderDictionary.TryGetValue(m.Id, out dep))
            //        {
            //            dep = m;
            //            dep.Persons = new List<Person>();
            //            orderDictionary.Add(dep.Id, dep);
            //        }
            //        dep.Persons.Add(n);
            //        return dep;
            //    }).Distinct().ToList();
            // var a13 = mdb.Query<Person, PR, Role, PR >("select * from Person,PR,Role where Person.Id=PR.PId and PR.RId=Role.Id", (m, n,z) => { n.Person =m;n.Role = z; return n; });
            //一对多
            //var personDictionary = new Dictionary<int, Person>();
            //var a14 = mdb.Query<Person, PR, Role, Person>("select * from Person,PR,Role where Person.Id=PR.PId and PR.RId=Role.Id",
            //    (m, n, z) => {
            //        Person per;
            //        if (!personDictionary.TryGetValue(m.Id,out per))
            //        {
            //            per = m;
            //            per.Roles = new List<Role>();
            //            personDictionary.Add(per.Id, per);
            //        }
            //        per.Roles.Add(z);
            //        return per;
            //    }
            //    ).Distinct().ToList();
            // var a15 = mdb.QueryFirst("select * from Person");
            // var a16 = mdb.QuerySingleOrDefault<Person>("select  * from Person limit 1");//Single必须保证查出来的只有一条数据，否则报错
            //多sql语句查询
            //using (var a17 = mdb.QueryMultiple("select  * from Person;select * from Role;"))
            //{
            //    var per = a17.Read<Person>();
            //    var role = a17.Read<Role>();
            //};
            //事务操作，必须先打开mdb;
            //mdb.Open();
            //using (var transaction=mdb.BeginTransaction())
            //{
            //    try
            //    {
            //        mdb.Execute("insert into user(a) values(@a)", new User { a = "10" });
            //        mdb.Execute("insert into user(a) values(@a)", new User { a = "1" });
            //        transaction.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        transaction.Rollback();
            //    }
            //}
            //打开之前就开始事务操作(不需要打开mdb)mdb.Open();
            //using (var tran = new TransactionScope())
            //{
            //    try
            //    {
            //        mdb.Execute("insert into user(a) values(@a)", new User { a = "2" });
            //        mdb.Execute("insert into user(a) values(@a)", new User { a = "3" });
            //        tran.Complete();
            //    }
            //    catch (Exception ex)
            //    {
            //        tran.Dispose();
            //    }
            //}
            //dapper.contrib 类似ef
            //var s = mdb.Get<User>(1);
            //var s = mdb.GetAll<User>();
            //var person = new Person() { Name = "mzj1",DId=1 };
            //var s = mdb.Insert(person);
            //var ss = mdb.Insert(new User() { a = "123" });
            //var ss = mdb.Insert(new[] {new  User() { a = "22" }, new User() { a = "33" } });
            //var ss = mdb.Insert(new List<User>() { new User() { a = "44" }, new User() { a = "55" } });
            //var sss = mdb.Delete(new[] { new User() { a = "22" }, new User() { a = "33" } });
            //var ss = mdb.DeleteAll<User>();
            // var ss = mdb.Update(new Person() {Id=3,Name="mmm",DId=1 });
            // var ss = mdb.Update( new[] { new Person{ Id = 3, Name = "mmm", DId = 1 }, new Person { Id = 2, Name = "menzujun", DId = 1 } });
            //datper.plus 批量操作
            //DapperPlusManager.Entity<User>().Table("user");赋值给表名
            // var x = mdb.BulkInsert(new List<User>() { new User() { a="aa"}, new User() { a = "bb" } });
            //DapperPlusManager.Entity<Person>().Table("Person").Identity(o => o.Id);
            //DapperPlusManager.Entity<Depatment>().Table("Depatment").Identity(o => o.Id);
            //一对一添加(需要注意一点就是需要指定Identity,否则自增无效，然后就是添加顺序，需要有先后顺序，如下添加员工后添加部门员工的部门Id是不会变的)
            //var person = new List<Person>() {  new Person() {Name = "Mzzzzz",DId =1,Depatment=new Depatment(){
            //        Id=1,
            //        Name="部门1"
            //    }},
            //    new Person(){Name="rrrr",DId=3,Depatment=new Depatment(){
            //        Id=3,
            //        Name="部门3"
            //    }
            //    }
            //};
            //var xs = mdb.BulkInsert(person[0]).ThenForEach(n => n.Depatment.Id = n.DId).ThenBulkInsert(n => n.Depatment);
            //var x = mdb.BulkInsert(person[1]).ThenForEach(n => n.Depatment.Id = n.DId).ThenBulkInsert(n => n.Depatment);
            //一对多添加
            //var dep = new Depatment() { Name = "test", Persons = new List<Person>()
            //{
            //    new Person()
            //    {
            //        Name="666"
            //    },
            //    new Person()
            //    {
            //        Name="777"
            //    },
            //} };
            //var x = mdb.BulkInsert(dep).ThenForEach(n=>n.Persons.ForEach(m=> { m.DId = n.Id;m.Name = "5da"+ n.Id; })).ThenBulkInsert(n=>n.Persons);
            //Dapper.SimpleCRUD 和 dapper.SimpleSave和dapper.contrib 选择一个即可，dapper.SimpleCRUD 拥有分页查询等方法（Get GetList GetListPaged Insert Update Delete DeleteList RecordCount）
            // dapper.SimpleSave 有 OneToMany OneToOne PrimaryKey等属性，Create CreateAll Update UpdateAll Delete DeleteAll SoftDelete SoftDeleteAll
            return null;
        }
    }
    [Table("user")]
    public class User
    {
        [ExplicitKey]
        public string a { get; set; }
    }
    [Table("Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DId { get; set; }

        [Write(false)]
        public virtual Depatment Depatment { get; set; }

        [Write(false)]
        public virtual List<Role> Roles { get; set; }
    }
    [Table("PR")]
    public class PR
    {
        [Key]
        public int Id { get; set; }
        public int PId { get; set; }
        public virtual Person Person { get; set; }
        public int RId { get; set; }
        public virtual Role Role { get; set; }
    }
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Table("Depatment")]
    public class Depatment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Person> Persons { get; set; }
    }
}

