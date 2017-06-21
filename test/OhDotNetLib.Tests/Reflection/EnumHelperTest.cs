using System;

using Xunit;
using Shouldly;

namespace OhDotNetLib.Tests.Reflection
{
    using OhDotNetLib.Reflection;
    using System.ComponentModel;
    using System.Linq;

    public class EnumHelperTest
    {
        [Fact]
        public void Enum_BaseOperatorShouldBeWork()
        {
            var enumInfo = new EnumMetaInfo(typeof(MyEnum));

            enumInfo.HasFlag.ShouldBe(true);
            enumInfo.Fields.Count().ShouldBe(4);
            enumInfo.Attributes.Count().ShouldBe(2);

            var enumInfo2 = new EnumMetaInfo<int>(typeof(MyEnum));
            enumInfo2.HasFlag.ShouldBe(true);

            enumInfo2.Fields.Count().ShouldBe(4);           

            enumInfo2.Attributes.Count().ShouldBe(2);
            enumInfo2.Fields.FirstOrDefault().Value.ShouldBe(2);
        }
    }

    [Flags]
    [My(Text = "my-test of MyEnum")]
    public enum MyEnum : int
    {
        Default = Processing,

        Processing = 2,

        [My(Text = "my-test of Completed")]
        Completed = 4,

        [Description("Task state canceled")]
        Canceled = 8
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class MyAttribute : Attribute
    {
        public MyAttribute()
            : this(string.Empty)
        {
        }

        public MyAttribute(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
    }
}
