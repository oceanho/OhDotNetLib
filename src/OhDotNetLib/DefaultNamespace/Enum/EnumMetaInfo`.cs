
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
            RealFields = new EnumFieldInfo<TValue>[Fields.Length];
            for (int i = 0; i < RealFields.Length; i++)
            {
                RealFields[i] = new EnumFieldInfo<TValue>()
                {
                    Name = Fields[i].Name,
                    Value = Fields[i].Value,
                    Attributes = Fields[i].Attributes,
                    RealValue = (TValue)Fields[i].Value
                };
            }
        }

        public EnumFieldInfo<TValue>[] RealFields { get; }
    }
}
