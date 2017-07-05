using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Text;

namespace OhDotNetLib.Reflection.Caching
{
    internal static class MethodInfoCache
    {
        private static readonly ConcurrentDictionary<Type, ImmutableList<MethodInfo>> cacheDb;
        private static readonly BindingFlags defaultBindingflags = BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        static MethodInfoCache()
        {
            cacheDb = new ConcurrentDictionary<Type, ImmutableList<MethodInfo>>();
        }

        public static IReadOnlyList<MethodInfo> Get(Type type, Func<Type, MethodInfo[]> getTypeMethodInfoHandler)
        {
            return cacheDb.GetOrAdd(type, getTypeMethodInfoHandler(type).ToImmutableList());
        }
        internal static void Reset()
        {
            cacheDb.Clear();
            RegisterInternal();
        }

        public static void RegisterInternal()
        {
            Get(typeof(String), (type) =>
            {
                return GetMethodByDefault(type);
            });
        }

        public static MethodInfo[] GetMethodByDefault(Type type)
        {
            return type.GetTypeInfo().GetMethods(defaultBindingflags);
        }
    }
}
