using OhDotNetLib.Reflection.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using System.Collections.Immutable;

namespace OhDotNetLib.Reflection
{
    /// <summary>
    /// 
    /// </summary>
    public static class MethodHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MethodInfo GetMethod(Type type, string name)
        {
            return GetMethod(type, name, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="isStatic"></param>
        /// <returns></returns>
        public static MethodInfo GetMethod(Type type, string name, bool isStatic)
        {
            return GetMethod(type, method => method.Name == name && (isStatic ? method.IsStatic : true));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static MethodInfo GetMethod(Type type, Func<MethodInfo, bool> predicate)
        {
            return MethodInfoCache.Get(type, (_type) =>
            {
                return MethodInfoCache.GetMethodByDefault(_type);
            }).FirstOrDefault(predicate);
        }
    }
}
