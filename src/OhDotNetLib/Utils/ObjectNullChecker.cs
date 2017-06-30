using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OhDotNetLib.Utils
{
    public static class ObjectNullChecker
    {
        public static bool IsNullOrEmpty(object source)
        {
            if (source == null)
                return true;
            return (source is string) && String.IsNullOrEmpty((source as string));
        }

        public static bool IsNullOrEmptyOfAnyOne(params object[] sources)
        {
            if (sources == null)
                return true;
            foreach (var source in sources)
            {
                if (IsNullOrEmpty(source))
                    return true;
            }
            return false;
        }
    }
}
