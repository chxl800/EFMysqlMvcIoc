using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace DAL.Base
{
    public class DBContextFactory
    {
        /// <summary>
        /// 帮我们返回当前线程内的数据库上下文，如果当前线程内没有上下文，那么创建一个上下文，并保证
        /// 上线问实例在线程内部是唯一的
        /// </summary>
        /// <returns></returns>
        public static DBContext GetDbContext()
        {
            DBContext dbContext = CallContext.GetData(typeof(DBContextFactory).Name) as DBContext;
            if (dbContext == null)
            {
                dbContext = new DBContext();
                CallContext.SetData(typeof(DBContextFactory).Name, dbContext);
            }
            return dbContext;
        }
    }
}
