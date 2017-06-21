using OhDotNetLib.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib.Extension.StringOfBase64
{
    public static class StringExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToReplacedBase64String(this string source)
        {
            if (!(ObjectNullChecker.IsNull(source)))
            {
                source = source.Replace('+', '-');
                source = source.Replace('/', '*');
                source = source.Replace('=', '_');
            }
            return source;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FromReplacedBase64String(this string source)
        {
            if (!(ObjectNullChecker.IsNull(source)))
            {
                source = source.Replace('-', '+');
                source = source.Replace('*', '/');
                source = source.Replace('_', '=');
            }
            return source;
        }
    }
}
