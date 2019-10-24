using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;

namespace Common.DTO
{
    /// <summary>
    /// 包含分页信息的集合列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T>
    {
        #region ctor

        public PagedList(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        /// <summary>
        /// 分页集合，同时设置分页信息
        /// </summary>
        /// <param name="condition"></param>
        public PagedList(PagedCondition condition = null)
        {
            SetPagedCondition(condition);
        }


        /// <summary>
        /// 根据一个集合创建一个分页集合，同时设置分页信息
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="condition"></param>
        public PagedList(IList<T> list, PagedCondition condition = null)
        {
            this.List = list;
            SetPagedCondition(condition);
        }


        /// <summary>
        /// 设置分页信息
        /// </summary>
        /// <param name="condition"></param>
        public void SetPagedCondition(PagedCondition condition)
        {
            if (condition == null)
            {
                return;
            }
            this.PageIndex = condition.PageIndex;
            this.PageSize = condition.PageSize;
        }

        #endregion

        /// <summary>
        /// 数据记录
        /// </summary>
        public IList<T> List { get; set; }


        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public long Total { get; set; }


        /// <summary>
        /// 页面总数，设置了PageSize和RecordTotal属性后自动计算
        /// </summary>
        public int PageCount
        {
            get
            {
                if (PageSize == 0 || Total == 0) return 0;

                return (Total / PageSize).ToInt() + (Total % PageSize > 0 ? 1 : 0);
            }
        }
        /// <summary>
        /// 增加返回扩展值（根据应用场景返回数据）
        /// </summary>
        public dynamic Data { get; set; }
    }


    public class PagedListAndsum<T> : PagedList<T>
    {
        public dynamic Sum { get; set; }
    }
}
