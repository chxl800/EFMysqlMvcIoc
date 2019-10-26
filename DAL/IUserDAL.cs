using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Base;
using Model;

namespace DAL
{
    public interface IUserDAL : IBaseDAL<User>
    {

        /// <summary>
        /// 查询关联表扩展
        /// </summary>
        /// <returns></returns>
        object GetListEF(User user = null);


        /// <summary>
        /// 查询关联表扩展
        /// </summary>
        /// <returns></returns>
        object GetListLinq(User user = null);

        /// <summary>
        /// 查询关联表扩展
        /// </summary>
        /// <returns></returns>
        object GetListSQL(User user = null);

        /// <summary>
        /// 修改SQL扩展
        /// </summary>
        /// <returns></returns>
        object UpdateUesrSQL(User user = null);
    }
}
