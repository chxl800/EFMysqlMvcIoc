using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// 表示当前操作结果的枚举
    /// </summary>
    public enum ResultStatus
    {

        /// <summary>
        ///   操作成功
        /// </summary>
        [Description("操作成功。")]
        Success = 0,

        /// <summary>
        ///   操作引发错误
        /// </summary>
        [Description("操作引发错误。")]
        Error = 1,

        /// <summary>
        ///   指定参数的数据不存在
        /// </summary>
        [Description("指定参数的数据不存在。")]
        QueryNull = 2,

        /// <summary>
        ///   输入信息验证失败
        /// </summary>
        [Description("输入信息验证失败。")]
        ValidError = 3,

        /// <summary>
        ///   操作取消或操作没引发任何变化
        /// </summary>
        [Description("操作没有引发任何变化，提交取消。")]
        NoChanged = 4,

        /// <summary>
        /// 用户登录已过期，请重新登录
        /// </summary>
        [Description("用户登录已过期，请重新登录。")]
        LoginError = 5,


    }
}
