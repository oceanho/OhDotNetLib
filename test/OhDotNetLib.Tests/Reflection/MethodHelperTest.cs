using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using OhDotNetLib.Reflection;

namespace OhDotNetLib.Tests.Reflection
{
    public class MethodHelperTest
    {
        #region Verify_GetMethodShouldBeWork

        [Fact]
        public void Verify_GetMethodShouldBeWork()
        {
            var strType = typeof(String);
            var strIsNullOrEmptyMethod = MethodHelper.GetMethod(strType, "IsNullOrEmpty");
            strIsNullOrEmptyMethod.ShouldNotBeNull();
            strIsNullOrEmptyMethod.Invoke(null, new object[] { string.Empty }).ShouldBe(true);
            strIsNullOrEmptyMethod.Invoke(null, new object[] { "this is test text" }).ShouldBe(false);
        }
        #endregion
    }
}
