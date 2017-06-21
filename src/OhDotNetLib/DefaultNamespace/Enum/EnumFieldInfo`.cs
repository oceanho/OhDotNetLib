
using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib
{
    /// <summary>
    /// 定义一个用于表示枚举字段元数据信息的实体类
    /// </summary>
    public class EnumFieldInfo<TValue> : EnumFieldInfo
    {
        /// <summary>
        /// 枚举值
        /// </summary>
        public TValue RealValue { get; set; }
    }
}
