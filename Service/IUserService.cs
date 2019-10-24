using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface IUserService
    {
        /// <summary>
        /// 查询全部用户
        /// </summary>
        /// <returns></returns>
        List<User> GetUsers();
    }
}
