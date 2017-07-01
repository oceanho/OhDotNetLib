using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Shouldly;

namespace OhDotNetLib.Tests.Extension
{
    using OhDotNetLib.Extension;

    public class ObjectCheckerExtensionTest
    {
        [Fact]
        public void IsEmptyShouldBeWork()
        {
            var str = string.Empty;
            str.IsEmpty().ShouldBe(true);
            "OceanHo".IsEmpty().ShouldBe(false);

            var list = new List<string>();
            list.IsEmpty().ShouldBe(true);
            list.Add("I'm Ocean");
            list.IsEmpty().ShouldBe(false);

            default(object).IsEmpty().ShouldBe(true);
        }
    }
}
