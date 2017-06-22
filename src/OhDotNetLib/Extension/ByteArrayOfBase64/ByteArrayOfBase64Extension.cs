using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OhDotNetLib.Extension
{
    public static partial class ByteArrayOfBase64Extension
    {
        public static string ToBase64Str(this IEnumerable<byte> source)
        {
            return Convert.ToBase64String(source.ToArray());
        }

        public static byte[] ToBase64Bytes(this IEnumerable<byte> source)
        {
            return source.ToBase64Bytes(Consts.DefaultEncoding);
        }

        public static byte[] ToBase64Bytes(this IEnumerable<byte> source, Encoding coding)
        {
            return coding.GetBytes(source.ToBase64Str());
        }
    }
}
