using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Shouldly;

namespace OhDotNetLib.Tests.Extension
{
    using OhDotNetLib.Extension;

    public class DateTimeOfSelfConversionExtensionTest
    {
        #region Verify_DateTimeConversionShouldBeWork

        [Fact]
        public void Verify_DateTimeConversionShouldBeWork()
        {
            var date = DateTime.Now.GetMinOfDay();
            var ts = date.GetUnixTimeStamp();
            ts.ToLocalDateTime().ShouldBe(date);
            ts.ToUtcDateTime().ShouldBe(date.ToUniversalTime());
        }
        #endregion
    }
}
