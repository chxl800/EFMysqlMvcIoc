using System.Data.Entity;
using System.Linq;
using DAL.Base;
using Model;
using Model.DTO.User;

namespace DAL.Impl
{
    public class UserDAL : BaseDAL<User>, IUserDAL
    {
        DbContext db = DBContextFactory.GetDbContext();


        /// <summary>
        /// 查询关联表扩展
        /// </summary>
        /// <returns></returns>
        public object GetListEF(User user = null)
        {
            //定义关联的实体
             return db.Set<User>().Join(db.Set<UserRole>(), u => u.Id, r => r.UserId, (u, r) => new UserRoleDto { Id=u.Id,UserName=u.UserName,RoleId= r.RoleId }).ToList();

            //匿名输出
            //return db.Set<User>().Join(db.Set<UserRole>(), u => u.Id, r => r.UserId, (u, r) => new { u, r.RoleId }).ToList();
        }

        /// <summary>
        /// 查询关联表扩展
        /// </summary>
        /// <returns></returns>
        public object GetListLinq(User user = null)
        {
            //匿名输出
            //var list = from u in db.Set<User>()
            //           join r in db.Set<UserRole>() on u.Id equals r.UserId
            //           select new
            //           {
            //               u.Id,
            //               u.UserName,
            //               r.RoleId
            //           };

            //参考linq https://www.cnblogs.com/xinwang/p/6145837.html
            var list = from u in db.Set<User>()
                       join r in db.Set<UserRole>() on u.Id equals r.UserId
                       select new UserRoleDto 
                       {
                           Id = u.Id,
                           UserName = u.UserName,
                           RoleId = r.RoleId
                       };
            return list;
        }
    }
}
