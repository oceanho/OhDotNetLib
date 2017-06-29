using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OhDotNetLib.Reflection
{
    public static class TypeHelper
    {
        #region IsGenirecType

        /// <summary>
        /// 判断一个指定 <paramref name="type"/> 是否属于泛型对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsGenericType(Type type)
        {
            return type.GetTypeInfo().IsGenericType;
        }
        #endregion

        #region IsGenericTypeDefinition

        /// <summary>
        /// 判断一个指定 <paramref name="type"/> 是否属于泛型对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsGenericTypeDefinition(Type type)
        {
            return type.GetTypeInfo().IsGenericTypeDefinition;
        }
        #endregion

        #region GetGenericTypeUniqueName

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetGenericTypeUniqueName(Type type)
        {
            var name = type.FullName;
            if (TypeHelper.IsGenericType(type))
            {
                name = name.Substring(0, name.IndexOf("`") + 1);
                name = $"{name}{type.GetTypeInfo().GetGenericArguments().Count()}";
            }
            return name;
        }
        #endregion
    }
}
