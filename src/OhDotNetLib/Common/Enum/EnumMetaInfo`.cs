
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
    public class EnumMetaInfo<TValue> : EnumMetaInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumTyper"></param>
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

        public new EnumFieldInfo<TValue>[] Fields { get; }
    }
}
