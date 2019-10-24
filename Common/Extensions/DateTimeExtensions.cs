using System;
using System.Globalization;

namespace Common.Extensions
{
    public static class DateTimeExtensions
    {
        #region 周号转换

        private static readonly GregorianCalendar Calendar = new GregorianCalendar();

        /// <summary>
        /// 将时间转换为周号 例如2017年第5周为：201705
        /// </summary>
        /// <returns></returns>
        public static int ToWeekNumber(this DateTime date)
        {
            return $"{date.Year}{Calendar.GetWeekOfYear(date.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday):00}"
                .ToInt();
        }

        /// <summary>
        /// 将周号转为Datetime默认为该周最后一天
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DateTime WeekNumberToDate(this int week)
        {
            var year = (week / 100).ToInt(); //取年份
            var date = DateTime.Parse($"{year}-01-01"); //构造该年日期
            var days = (week % 100) * 7 - date.DayOfWeek.ToWeekInt(); //去天数并减去第一周的星期数
            date = date.AddDays(days); //追加日期
            return date.Date;
        }

        /// <summary>
        /// 返回星期对应的数字，周一为1，周日为7
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int ToWeekInt(this DayOfWeek day)
        {
            return day == DayOfWeek.Sunday ? 7 : (int)day;
        }

        /// <summary>
        /// 将日期调整到本周指定的某一天
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime ToDayOfWeek(this DateTime date, DayOfWeek week)
        {
            
            return date.AddDays(week.ToWeekInt()-date.DayOfWeek.ToWeekInt());
        }
        #endregion

        #region 月号转换

        /// <summary>
        /// 将时间转换为月号 例如2017年5月为：201705
        /// </summary>
        /// <returns></returns>
        public static int ToMonthNumber(this DateTime date)
        {
            return date.ToString("yyyyMM").ToInt();
        }

        /// <summary>
        /// 将月号转换为Datetime默认为该月最后一天
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public  static DateTime MonthNumberToDate(this int month)
        {
            var year = (month / 100).ToInt(); //取年份
            var date = DateTime.Parse($"{year}-{(month % 100)}-01"); //构造该年日期
            date = date.AddMonths(1).AddDays(-1); //追加一个月并减去一天为最后一天
            return date;
        }
        /// <summary>
        /// 时间转换为本月最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToLastDay(this DateTime date)
        {
            return date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1);
        }

        #endregion

        #region 时间戳转换
        /// <summary>
        /// 时间戳转成DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timestamp)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return startTime.AddMilliseconds(timestamp);
        }

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToUnixTimestamp(this DateTime time)
        {
            return  (time.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }


        /// <summary>
        /// 计算时间的时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToTimestamp(this DateTime time)
        {
            TimeSpan ts = time - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ((Int64)ts.TotalMilliseconds);
        }
        #endregion


    }
}