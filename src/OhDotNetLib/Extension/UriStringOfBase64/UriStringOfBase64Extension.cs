using OhDotNetLib.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib.Extension
{
    public static partial class UriStringOfBase64Extension
    {
        /// <summary>
        /// 按照 + --> - 、 / --> _ . 去掉= 的模式，替换其中的特殊字符base64字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToReplacedUrlSpecialCharacter(this string source)
        {
            if (!(ObjectNullChecker.IsNullOrEmpty(source)))
            {
                var builder = new StringBuilder(source);
                builder.Replace("=", "");
                builder.Replace("+", "-");
                builder.Replace("/", "_");
                source = builder.ToString();
            }
            return source;
        }

        /// <summary>
        /// 按照 - --> + 、 _ --> / 、 补足= 的模式，还原被替换的base64字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FromReplacedUrlSpecialCharacter(this string source)
        {
            if (!(ObjectNullChecker.IsNullOrEmpty(source)))
            {
                var builder = new StringBuilder(source);
                builder.Replace('-', '+');
                builder.Replace('_', '/');
                source = builder.ToString();
            }
            return source;
        }
    }
}
