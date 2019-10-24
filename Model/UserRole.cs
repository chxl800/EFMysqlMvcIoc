using System;
namespace Model
{
    /// <summary>
    /// 用户与角色关联
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// 
        /// </summary>   
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string RoleId { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public int Status { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Creator { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Reviser { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public DateTime? ReviseTime { get; set; }
    }
}

