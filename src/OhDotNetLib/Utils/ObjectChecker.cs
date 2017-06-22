using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib.Utils
{
    internal static class ObjectChecker
    {
        public static void CheckNotNull(object source)
        {
            if (ObjectNullChecker.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException($"{nameof(source)}");
            }
        }
    }
}
