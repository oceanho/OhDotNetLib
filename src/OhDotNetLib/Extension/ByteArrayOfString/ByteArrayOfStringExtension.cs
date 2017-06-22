using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OhDotNetLib;

namespace OhDotNetLib.Extension
{
    public static partial class ByteArrayOfStringExtension
    {
        public static string GetString(this IEnumerable<byte> source)
        {
            return source.GetString(Consts.DefaultEncoding);
        }

        public static string GetString(this IEnumerable<byte> source, Encoding encoding)
        {
            return encoding.GetString(source.ToArray());
        }

        public static byte[] GetBytes(this string source)
        {
            return source.GetBytes(Consts.DefaultEncoding);
        }

        public static byte[] GetBytes(this string source, Encoding encoding)
        {
            return encoding.GetBytes(source);
        }
    }
}
