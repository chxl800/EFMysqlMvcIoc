using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;

namespace Common.DTO
{
    public class Result<T>
    {
        #region property


        public int Code { get; set; }
        public ResultStatus Status { get; set; }

        public T Data { get; set; }

        /// <summary>
        /// 获取或设置 返回消息
        /// </summary>
        public string Message
        {
            get { return _message ?? Status.ToDescription(); }
            set { _message = value; }
        }

        #region helper

        /// <summary>
        /// 获取 是否成功
        /// </summary>
        public bool IsSuccessed => this.Status == ResultStatus.Success;

        #region 快捷改状态

        /// <summary>
        /// 设置当前结果类的操作成功了
        /// </summary>
        /// <param name="item">返回值</param>
        /// <param name="message">提示消息。</param>
        public void Successed(string message)
        {
            Successed(default(T), message);
        }

        /// <summary>
        /// 设置当前结果类的操作成功了
        /// </summary>
        /// <param name="item">返回值</param>
        /// <param name="message">提示消息。</param>
        public void Successed(T item = default(T), string message = null)
        {
            if (item.IsNotNull())
                this.Data = item;
            this.Status = ResultStatus.Success;
            if (!message.IsNullOrEmpty())
                this.Message = message;
        }

        /// <summary>
        /// 设置当前结果类的操作出错了
        /// </summary>
        /// <param name="message">错误信息，为空时使用默认的错误信息。</param>
        /// <param name="ex">异常对象，用户DEBUG状态下方便调试</param>
        public void Errored(string message = null)
        {
            this.Status = ResultStatus.Error;
            if (!message.IsNullOrEmpty())
                this.Message = message;
        }

        /// <summary>
        /// 用户登录过期，需重新登录返回的错误信息
        /// </summary>
        /// <param name="message">错误信息，为空时提示：用户登录已过期，请重新登录</param>
        public void LoginErrored(string message = null)
        {
            this.Status = ResultStatus.LoginError;
            if (!message.IsNullOrEmpty())
                this.Message = message;
        }


        /// <summary>
        /// 设置当前结果类的验证失败
        /// </summary>
        /// <param name="message">错误信息，为空时使用默认的错误信息。</param>
        public void ValidError(string message = null)
        {
            this.Status = ResultStatus.ValidError;
            if (!message.IsNullOrEmpty())
                this.Message = message;
        }

        /// <summary>
        /// 设置当前结果类的验证失败
        /// </summary>
        /// <param name="item"></param>
        /// <param name="message"></param>
        public void ValidError(T item = default(T), string message = null)
        {
            if (item.IsNotNull())
                this.Data = item;
            this.Status = ResultStatus.ValidError;
            if (!message.IsNullOrEmpty())
                this.Message = message;
        }

        /// <summary>
        /// 设置当前结果类没有获取到数据
        /// </summary>
        /// <param name="message">错误信息，为空时使用默认的错误信息。</param>
        public void QueryNull(string message = null)
        {
            this.Status = ResultStatus.QueryNull;
            if (!message.IsNullOrEmpty())
                this.Message = message;
        }
        #endregion

        #region 快捷创建

        /// <summary>
        /// 创建一个 操作成功的操作结果
        /// </summary>

        public static Result<T> Success => new Result<T>(ResultStatus.Success);

        /// <summary>
        /// 创建一个 未变更的操作结果
        /// </summary>

        public static Result<T> NoChanged => new Result<T>(ResultStatus.NoChanged);

        /// <summary>
        /// 创建一个 出错的的操作结果
        /// </summary>

        public static Result<T> Error => new Result<T>(ResultStatus.Error);

        /// <summary>
        /// 创建一个 登录过期的错误
        /// </summary>

        public static Result<T> LoginError => new Result<T>(ResultStatus.LoginError);

        #endregion

        #endregion

        #endregion

        #region vars

        private string _message;

        #endregion

        /// <summary>
        /// 获取Data,非Success抛出VerifyException异常
        /// </summary>
        /// <returns></returns>
        ///<see cref="VerifyException"/>
        public T GetDataOrThrow()
        {
            return GetDataOrThrow(new Exception(this.Message));
        }

        /// <summary>
        /// 获取Data,非Success抛出指定异常
        /// </summary>
        /// <param name="exception">异常</param>
        /// <returns></returns>
        public T GetDataOrThrow(Exception exception)
        {
            if (this.IsSuccessed)
                return Data;

            throw exception;
        }

        #region ctor

        static Result()
        {
        }


        public Result()
            : this(ResultStatus.NoChanged)
        {
        }


        public Result(ResultStatus status)
            : this(status, null, default(T))
        {
        }


        public Result(ResultStatus status, string message)
            : this(status, message, default(T))
        {
        }

        public Result(ResultStatus status, string message, T data)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }

        #endregion
    }

    /// <summary>
    /// 业务操作结果信息类，对操作结果进行封装
    /// </summary>
    public class Result : Result<object>
    {
        /// <summary>
        /// 初始化一个<see cref="Result"/>类型的新实例
        /// </summary>
        public Result()
            : this(ResultStatus.NoChanged)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="Result"/>类型的新实例
        /// </summary>
        public Result(ResultStatus status)
            : this(status, null, null)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="Result"/>类型的新实例
        /// </summary>
        public Result(ResultStatus status, string message)
            : this(status, message, null)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="Result"/>类型的新实例
        /// </summary>
        public Result(ResultStatus status, string message, object data)
            : base(status, message, data)
        {
        }

        /// <summary>
        /// 获取 成功的操作结果
        /// </summary>

        public new static Result Success => new Result(ResultStatus.Success);

        /// <summary>
        /// 获取 未变更的操作结果
        /// </summary>

        public new static Result NoChanged => new Result(ResultStatus.NoChanged);

        /// <summary>
        /// 获取 出错的操作结果
        /// </summary>

        public new static Result Error => new Result(ResultStatus.Error);

        /// <summary>
        /// 获取 登录过期的错误
        /// </summary>

        public new static Result LoginError => new Result(ResultStatus.LoginError);
    }
}
