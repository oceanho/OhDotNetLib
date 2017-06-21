using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib.Extension
{
    public static partial class StringExtension
    {
        public static string ToBase64Str(this string source)
        {
        }

        public static string ToBase64Str(this string source, Encoding encoding)
        {
            return Convert.ToBase64String(source.GetBytes(encoding));
        }

        public static string FromBase64Str(this string source)
        {
        }

        public static string FromBase64Str(this string source, Encoding encoding)
        {
            // return Convert.FromBase64String((source.GetBytes(encoding).GetStr(encoding))).ToStr();
        }
    }
}
