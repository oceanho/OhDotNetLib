using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OhDotNetLib.Utils
{
    public static class ObjectChecker
    {
        public static void CheckNotNull(object source)
        {
            if (ObjectNullChecker.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException($"{nameof(source)}");
            }
        }
        public static void CheckNotNullAnyOne(params object[] sources)
        {
            CheckNotNull(sources);
            foreach (var source in sources)
            {
                CheckNotNull(source);
            }
        }
    }
}
