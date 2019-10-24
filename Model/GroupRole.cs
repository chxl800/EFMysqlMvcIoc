using System;

namespace Model
{
    /// <summary>
    /// 用户组与角色关联
    /// </summary>
    public class GroupRole
    {
        /// <summary>
        /// 
        /// </summary>   
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string GroupId { get; set; }
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