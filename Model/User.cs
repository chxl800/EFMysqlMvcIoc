﻿using System;

namespace Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User
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
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Salt { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public int UserType { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string RealName { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string Phone { get; set; }
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
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public DateTime? LoginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>   
        public string IP { get; set; }
    }
}