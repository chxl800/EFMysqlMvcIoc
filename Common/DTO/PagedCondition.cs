using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    /// <summary>
    /// 分页传参模型，可以自动计算页数，开始记录和结束记录
    /// </summary>
    public class PagedCondition
    {
        public PagedCondition() : this(1, 50)
        {
        }

        public PagedCondition(int pageSize) : this(1, pageSize)
        {
        }

        public PagedCondition(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        private int _pageIndex = 1;

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                if (_pageIndex <= 0)
                    _pageIndex = 1;
                else
                    _pageIndex = value;
            }
        }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 跳过的记录数，设置了PageIndex，PageSize后自动计算。
        /// 用于lambda中的Skip方法
        /// </summary>
        public int Skip => (PageIndex - 1 > 0 ? PageIndex - 1 : 0) * PageSize;

        /// <summary>
        /// 当前页取值的开始记录，设置了PageIndex，PageSize后自动计算。
        /// 用于SQL语句中的between
        /// </summary>
        public int BeginRecord => Skip + 1;

        /// <summary>
        /// 当前页取值的结束记录，设置了PageIndex，PageSize后自动计算
        /// 用于SQL语句中的between
        /// </summary>
        public int EndRecord => Skip + PageSize;

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; }


        /// <summary>
        /// 排序方式
        /// </summary>
        public SortOrderType SortOrder { get; set; }
    }

    public enum SortOrderType
    {
        Asc = 0,
        Desc = 1
    }
}
