using OhDotNetLib.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib.Extension.StringOfUrlSpecialCharacterWithBase64
{
    public static class StringExtension
    {
        /// <summary>
        /// 按照 + --> -. / --> * . = --> _ 的替换模式，还原被替换的base64字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToReplacedUrlSpecialCharacter(this string source)
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
        /// 按照 - --> + . * --> / . _ --> = 的替换模式，还原被替换的base64字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FromReplacedUrlSpecialCharacter(this string source)
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
