using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OhDotNetLib.Extension
{
    public static partial class DateTimeOfSelfConversionExtension
    {
        private const long unix_ts_const = 621355968000000000;
        /// <summary>
        /// 获取指定时间的当天的最小时间（返回日期 <paramref name="source"/> 当天 00:00:00 时刻的时间）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime GetMinOfDay(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, source.Day, 00, 00, 00);
        }

        /// <summary>
        /// 获取指定时间的当天的最大时间（返回日期 <paramref name="source"/> 当天 23:59:59 时刻的时间）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime GetMaxOfDay(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, source.Day, 23, 59, 59);
        }

        /// <summary>
        /// 获取指定时间的 Unix TimeStamp
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static long GetUnixTimeStamp(this DateTime source)
        {
            return (long)((source.ToUniversalTime().Ticks - unix_ts_const) / 10000000);
        }

        /// <summary>
        /// 获取指定的 Unix TimeStamp Utc 时间
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime ToUtcDateTime(this Int32 source)
        {
            return new DateTime((source * 10000000 + unix_ts_const), DateTimeKind.Utc);
        }



        /// <summary>
        /// 获取指定的 Unix TimeStamp Utc 时间
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime ToUtcDateTime(this Int64 source)
        {
            return new DateTime((source * 10000000 + unix_ts_const), DateTimeKind.Utc);
        }

        /// <summary>
        /// 获取指定的 Unix TimeStamp Local 时间
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime ToLocalDateTime(this Int32 source)
        {
            return source.ToUtcDateTime().ToLocalTime();
        }

        /// <summary>
        /// 获取指定的 Unix TimeStamp Local 时间
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime ToLocalDateTime(this Int64 source)
        {
            return source.ToUtcDateTime().ToLocalTime();
        }
    }
}
