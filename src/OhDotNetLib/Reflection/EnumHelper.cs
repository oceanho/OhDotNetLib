using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace OhDotNetLib.Reflection
{
    /// <summary>
    /// Enum Helper
    /// </summary>
    public static class EnumHelper
    {
        #region CheckType

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        internal static void CheckType(Type type)
        {
            if (type.GetTypeInfo().BaseType != typeof(Enum))
            {
                throw new ArgumentException($"{type} is not a enum type");
            }
        }
        #endregion
        
        #region GetFieldInfo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static EnumFieldInfo[] GetFieldInfo(Type type)
        {
            return GetFieldInfo(type, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static EnumFieldInfo[] GetFieldInfo(Type type, bool inherit)
        {
            CheckType(type);
            var list = new List<EnumFieldInfo>();

            var inst = Activator.CreateInstance(type);
            var fields = type.GetTypeInfo().GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (var field in fields)
            {
                var enumFieldInfo = new EnumFieldInfo();
                enumFieldInfo.Name = field.Name;
                enumFieldInfo.Value = field.GetValue(inst);
                enumFieldInfo.Attributes = ReflectionHelper.GetAttributes(type, inherit);
                list.Add(enumFieldInfo);
            }
            return list.ToArray();
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
            CheckType(type);
            return ReflectionHelper.GetAttributes(type, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static Attribute[] GetAttributes(Type type, bool inherit)
        {
            CheckType(type);
            return ReflectionHelper.GetAttributes(type, inherit);
        }
        #endregion
    }
}
