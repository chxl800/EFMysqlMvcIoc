using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using DAL.Base;
using Model;
using Model.DTO.User;

namespace DAL.Impl
{
    public class UserDAL : BaseDAL<User>, IUserDAL
    {
        DBContext db = DBContextFactory.GetDbContext();


        /// <summary>
        /// 查询关联表扩展
        /// </summary>
        /// <returns></returns>
        public object GetListEF(User user = null)
        {
            //定义关联的实体
            //return db.User.GroupJoin(db.UserRole, u => u.Id, r => r.UserId, (u, r) => new { Id=u.Id,UserName=u.UserName,r }).ToList(); //左链接

            return db.User.Join(db.UserRole, u => u.Id, r => r.UserId, (u, r) => new UserRoleDto { Id = u.Id, UserName = u.UserName, RoleId = r.RoleId }).ToList();

            //匿名输出
            //return db.User.Join(db.UserRole, u => u.Id, r => r.UserId, (u, r) => new { u, r.RoleId }).ToList();
        }

        /// <summary>
        /// 查询关联表扩展 
        /// </summary>
        /// <returns></returns>
        public object GetListLinq(User user = null)
        {
            //参考linq https://www.cnblogs.com/xinwang/p/6145837.html

            //匿名输出
            //var list = from u in db.User
            //           join r in db.UserRole on u.Id equals r.UserId
            //           select new
            //           {
            //               u.Id,
            //               u.UserName,
            //               r.RoleId
            //           };

            var list = from u in db.User
                       join r in db.UserRole on u.Id equals r.UserId
                       select new UserRoleDto
                       {
                           Id = u.Id,
                           UserName = u.UserName,
                           RoleId = r.RoleId
                       };

            return list;
        }


        /// <summary>
        /// 查询关联表扩展
        /// </summary>
        /// <returns></returns>
        public object GetListSQL(User user = null)
        {

            //大多参考这样写，但是报错
            //List<SqlParameter> parms = new List<SqlParameter>();
            //parms.Add(new SqlParameter { ParameterName = "@status1", Value = 0 });
            //parms.Add(new SqlParameter { ParameterName = "@status2", Value = 0 });
            //return db.Database.SqlQuery<UserRoleDto>("select u.Id,u.UserName,r.RoleId from user u inner join userrole r on u.id=r.userid where u.status=@status1 and r.status=@status2", parms);

            return db.Database.SqlQuery<UserRoleDto>("select u.Id,u.UserName,r.RoleId from user u inner join userrole r on u.id=r.userid where u.status={0} and r.status={1}", new object[]{0,0}).ToList();
        }

        /// <summary>
        /// 修改SQL
        /// </summary>
        /// <returns></returns>
        public object UpdateUesrSQL(User user = null)
        {
            return db.Database.ExecuteSqlCommand("update user set RealName={0},Email={1} where id={2}", new object[] { "测试员", "xxx@11.com", "08d54e2201b85ae0fada9ea99c740ef0" });
        }
    }
}
