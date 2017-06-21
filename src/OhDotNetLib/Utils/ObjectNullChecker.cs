using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib.Utils
{
    internal static class ObjectNullChecker
    {
        public static bool IsNull(object obj1)
        {
            if (obj1 == null)
                return true;
            return (obj1 is string) && String.IsNullOrEmpty((obj1 as string));
        }
    }
}
