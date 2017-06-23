using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Text;

namespace OhDotNetLib.Reflection.Caching
{
    internal static class PropertyInfoCache
    {
        private static readonly ConcurrentDictionary<Type, ImmutableList<PropertyInfo>> CacheDb;
        static PropertyInfoCache()
        {
            CacheDb = new ConcurrentDictionary<Type, ImmutableList<PropertyInfo>>();
        }

        public static IReadOnlyList<PropertyInfo> Get(Type type, Func<Type, PropertyInfo[]> getTypePropertyInfoHandler)
        {
            if (!(CacheDb.ContainsKey(type)))
            {
                CacheDb[type] = getTypePropertyInfoHandler(type).ToImmutableList();
            }
            return CacheDb[type];
        }
    }
}
