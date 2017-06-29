using System;
using System.Collections.Generic;
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
    }
}
