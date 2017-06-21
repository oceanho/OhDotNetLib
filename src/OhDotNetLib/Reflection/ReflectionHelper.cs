using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace OhDotNetLib.Reflection
{
    /// <summary>
    /// Reflection Helper
    /// </summary>
    public static class ReflectionHelper
    {
        #region GetProperties
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="canAssignType"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetProperties(object source, Type canAssignType)
        {
            return source.GetType().GetTypeInfo().GetProperties().Where(prop => canAssignType.GetTypeInfo().IsAssignableFrom(prop.PropertyType.GetTypeInfo()));
        }
        #endregion

        #region GetAttributes

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static Attribute[] GetAttributes(Type type)
        {
            return GetAttributes(type, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static Attribute[] GetAttributes(Type type, bool inherit)
        {
            return GetAttributes<Attribute>(type, inherit);
        }
        #endregion

        #region GetTypeUniqueName

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeUniqueName(Type type)
        {
            var typeName = type.FullName;
            if (typeName == null)
            {
                typeName = type.AssemblyQualifiedName;
            }
            if (typeName == null)
            {
                typeName = type.ToString();
            }
            return typeName;
        }
        #endregion

        #region GetAttributes<TAttribute>

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static TAttribute[] GetAttributes<TAttribute>(Type type)
            where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(type, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static TAttribute[] GetAttributes<TAttribute>(Type type, bool inherit)
            where TAttribute : Attribute
        {
            return type.GetTypeInfo().GetCustomAttributes(typeof(TAttribute), inherit: inherit).OfType<TAttribute>().ToArray();
        }
        #endregion
    }
}
