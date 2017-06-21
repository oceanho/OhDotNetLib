using OhDotNetLib.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib.Extension
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 按照 + --> - 、 / --> _ . 去掉= 的替换模式，还原被替换的base64字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToReplacedUrlSpecialCharacter(this string source)
        {
            if (!(ObjectNullChecker.IsNull(source)))
            {
                source = source.Replace('+', '-');
                source = source.Replace('/', '_');
                source = source.Remove(source.IndexOf("="));
            }
            return source;
        }

        /// <summary>
        /// 按照 - --> + 、 _ --> / 、 补足= 的替换模式，还原被替换的base64字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FromReplacedUrlSpecialCharacter(this string source)
        {
            if (!(ObjectNullChecker.IsNull(source)))
            {
                source = source.Replace('-', '+');
                source = source.Replace('_', '/');
            }
            return source;
        }
    }
}
