using System;

using Xunit;
using Shouldly;
using OhDotNetLib.Utils;

namespace OhDotNetLib.Tests
{
    public class ObjectNullCheckerTest
    {
        #region Verify_IsNullOrEmptyOfAnyOneShouldBeWork


        [Fact]
        public void Verify_IsNullOrEmptyOfAnyOneShouldBeWork()
        {
            var str = string.Empty;
            ObjectNullChecker.IsNullOrEmptyOfAnyOne(str).ShouldBe(true);

            // str.ToUppper() should not raise expression , because of str == null . it will stop continue execute
            ObjectNullChecker.IsNullOrEmptyOfAnyOne(str, str.ToUpper()).ShouldBe(true);
        }
        #endregion
    }
}
