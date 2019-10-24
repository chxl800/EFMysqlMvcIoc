using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace Service.Impl
{
    public class UserService : IUserService
    {
        private IUserDAL userDAL;
        public UserService(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        /// <summary>
        /// 查询全部用户
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {

            List<User> users= userDAL.QueryWhere(s => true);
            return users;
        }
    }
}
