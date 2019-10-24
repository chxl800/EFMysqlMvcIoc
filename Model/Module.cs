using System;
namespace Model
{
    /// <summary>
    /// 权限模块
    /// </summary>
    public class Module
    {
        /// <summary>
        /// 
        /// </summary>   
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string ModuleName { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string PowerName { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string NavCls { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public int ModuleType { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public int OrderBy { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Code { get; set; }
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
        public int Status { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public bool IsHome { get; set; }
    }
}

