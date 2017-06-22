using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib.Utils
{
    internal static class ObjectNullChecker
    {
        public static bool IsNullOrEmpty(object source)
        {
            if (source == null)
                return true;
            return (source is string) && String.IsNullOrEmpty((source as string));
        }
    }
}
