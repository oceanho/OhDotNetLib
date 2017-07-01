using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OhDotNetLib.Utils;
using System.Collections;

namespace OhDotNetLib.Extension
{
    public static partial class ObjectCheckerExtension
    {
        public static bool IsEmpty(this object source)
        {
            var result = ObjectNullChecker.IsNullOrEmpty(source);            
            if (!result)
            {
                if (source.GetType() == typeof(String))
                {
                    return result;
                }

                var target = source as IEnumerable;
                if (target != null)
                {
                    return !(target.GetEnumerator().MoveNext());
                }
            }
            return result;
        }
    }
}
