
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OhDotNetLib
{
    /// <summary>
    /// 表示枚举元数据信息载体类
    /// </summary>
    public class EnumMetaInfo<TValue> : EnumMetaInfo
    {
        /// <summary>
        /// 实例化 <see cref="EnumFieldInfo{TValue}"/>
        /// </summary>
        /// <param name="enumTyper">枚举类型</param>
        public EnumMetaInfo(Type enumTyper)
            : base(enumTyper)
        {
            Fields = new EnumFieldInfo<TValue>[base.Fields.Length];
            for (int i = 0; i < Fields.Length; i++)
            {
                Fields[i] = new EnumFieldInfo<TValue>()
                {
                    Name = base.Fields[i].Name,
                    Value = (TValue)base.Fields[i].Value,
                    Attributes = base.Fields[i].Attributes
                };
            }
        }

        /// <summary>
        /// 获取一个值，该值表示指定的枚举类型所定义的所有字段数组
        /// </summary>
        public new EnumFieldInfo<TValue>[] Fields { get; }
    }
}
