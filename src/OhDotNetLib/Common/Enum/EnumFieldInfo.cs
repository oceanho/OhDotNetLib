
using System;

namespace OhDotNetLib
{
    /// <summary>
    /// 定义一个用于表示枚举字段元数据信息的实体类
    /// </summary>
    public class EnumFieldInfo
    {
        /// <summary>
        /// 枚举键
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 枚举值
        /// </summary>
        public object Value { get; set; }
        
        /// <summary>
        /// 枚举字段的 <see cref="Attribute"/> 数组列表
        /// </summary>
        public Attribute[] Attributes { get; set; }
    }
}
