using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.User
{
    /// <summary>
    /// 定义返回的实体 ,可以定义页面传参 等，注意命名规范
    /// </summary>
    public class UserRoleDto
    {
        /// <summary>
        /// 
        /// </summary>   
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>   
        public string RoleId { get; set; }

    }
}
