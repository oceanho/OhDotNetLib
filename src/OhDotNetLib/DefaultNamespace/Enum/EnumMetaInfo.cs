
using OhDotNetLib.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OhDotNetLib
{
    /// <summary>
    /// 表示枚举元数据类型的
    /// </summary>
    public class EnumMetaInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumTyper"></param>
        public EnumMetaInfo(Type enumTyper)
        {
            Fields = EnumHelper.GetFieldInfo(enumTyper, true);
            Attributes = EnumHelper.GetAttributes(enumTyper, true);
            HasFlag = Attributes.FirstOrDefault(p => p.GetType() == typeof(FlagsAttribute)) != null;
        }

        /// <summary>
        /// 获取一个值，该值表示枚举是否有 <see cref="FlagsAttribute"/>
        /// </summary>
        public bool HasFlag { get; }

        /// <summary>
        /// 获取一个值，该值表示枚举对象所定义的 <see cref="Attribute"/> 数组列表
        /// </summary>
        public Attribute[] Attributes { get; }

        /// <summary>
        /// 获取一个值，该值表示指定的枚举类型所定义的所有字段数组
        /// </summary>
        public EnumFieldInfo[] Fields { get; }
    }
}
