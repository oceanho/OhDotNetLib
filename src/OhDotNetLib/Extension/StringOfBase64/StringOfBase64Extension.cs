using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OhDotNetLib.Extension
{
    public static partial class StringOfBase64Extension
    {
        public static string ToBase64Str(this string source)
        {
            return source.ToBase64Str(Encoding.UTF8);
        }

        public static string ToBase64Str(this string source, Encoding encoding)
        {
            return Convert.ToBase64String(source.GetBytes(encoding));
        }

        public static string FromBase64Str(this string source)
        {
            return source.FromBase64Str(Encoding.UTF8);
        }

        public static string FromBase64Str(this string source, Encoding encoding)
        {
            return Convert.FromBase64String((source.GetBytes(encoding).GetString(encoding))).GetString();
        }
    }
}
