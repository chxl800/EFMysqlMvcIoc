using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using DAL;
using DAL.Base;
using Model;

namespace Service.Impl
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserService : IUserService
    {
        DbContext db = DBContextFactory.GetDbContext();
        private IUserDAL userDAL;
        public UserService(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        /// <summary>
        /// 查询全部用户
        /// </summary>
        /// <returns></returns>
        public Result<List<User>> GetUsers(User user = null)
        {
            var result = new Result<List<User>>();
            try
            {
                var users = userDAL.QueryWhere(s => true);
                result.Successed(users);
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public Result<User> GetEntity(User user)
        {
            var result = new Result<User>();
            try
            {
                var entity=userDAL.QueryEntity(s => s.Id == user.Id);
                result.Successed(entity);
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 查询关联表
        /// </summary>
        /// <returns></returns>
        public Result GetListEF(User user = null)
        {
            var result = new Result();
            try
            {
                var list = userDAL.GetListEF(user);
                result.Successed(list);
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 查询关联表
        /// </summary>
        /// <returns></returns>
        public Result GetListLinq(User user = null)
        {
            var result = new Result();
            try
            {
                var list = userDAL.GetListLinq(user);
                result.Successed(list);
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 查询关联表
        /// </summary>
        /// <returns></returns>
        public Result GetListSQL(User user = null)
        {
            var result = new Result();
            try
            {
                var list = userDAL.GetListSQL(user);

                result.Successed(list);
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public Result AddUser(User user)
        {
            var result = new Result();
            try
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    userDAL.Add(user);
                    userDAL.SaveChanges();

                    tran.Commit();
                    result.Successed();
                }
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result; 
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public Result UpdateUser(User user, string[] propertyNames=null)
        {
            var result = new Result();
            try
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    userDAL.Update(user, propertyNames);
                    userDAL.SaveChanges();

                    tran.Commit();
                    result.Successed();
                }
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result;
            
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public Result UpdateUserAll(User user)
        {
            var result = new Result();
            try
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    var entity = userDAL.QueryEntity(s => s.Id == user.Id);
                    entity.Phone = user.Phone;
                    entity.RealName = user.RealName;
                    entity.Email = user.Email;
                    userDAL.SaveChanges();

                    tran.Commit();
                    result.Successed();
                }
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result;

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public Result DeleteUser(User user)
        {
            var result = new Result();
            try
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    userDAL.Delete(user);
                    userDAL.SaveChanges();

                    tran.Commit();
                    result.Successed();
                }
               
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result;
            
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public Result UpdateUesrSQL(User user)
        {
            var result = new Result();
            try
            {
                var data = userDAL.UpdateUesrSQL(user);
                result.Successed(data);
            }
            catch (Exception ex)
            {
                result.Errored(ex.Message);
            }
            return result;

        }
    }
}
