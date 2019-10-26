using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Model;

namespace Service
{
    public interface IUserService
    {
        /// <summary>
        /// 查询全部用户
        /// </summary>
        /// <returns></returns>
        Result<List<User>> GetUsers(User user = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        Result<User> GetEntity(User user);

        /// <summary>
        /// 查询关联表扩展
        /// </summary>
        /// <returns></returns>
        Result GetListEF(User user = null);


        /// <summary>
        /// 查询关联表扩展
        /// </summary>
        /// <returns></returns>
        Result GetListLinq(User user = null);


        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        Result AddUser(User user);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        Result UpdateUser(User user, string[] propertyNames = null);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        Result UpdateUserAll(User user);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        Result DeleteUser(User user);
    
    }
}
