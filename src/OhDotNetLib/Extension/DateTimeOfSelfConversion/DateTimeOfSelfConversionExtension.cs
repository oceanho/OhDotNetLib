using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OhDotNetLib.Extension
{    
    public static partial class DateTimeOfSelfConversionExtension
    {
        /// <summary>
        /// 获取当前指定时间的当天的最小时间（返回日期 <paramref name="source"/> 当天 00:00:00 时刻的时间）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime GetMinOfDay(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, source.Day, 00, 00, 00);
        }

        /// <summary>
        /// 获取当前指定时间的当天的最大时间（返回日期 <paramref name="source"/> 当天 23:59:59 时刻的时间）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime GetMaxOfDay(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, source.Day, 23, 59, 59);
        }
    }
}
