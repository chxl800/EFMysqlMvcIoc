using System;
namespace Model
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 
        /// </summary>   
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string RoleName { get; set; }
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
        /// <summary>
        /// 
        /// </summary>   
        public int OrderBy { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Remark { get; set; }
    }
}

