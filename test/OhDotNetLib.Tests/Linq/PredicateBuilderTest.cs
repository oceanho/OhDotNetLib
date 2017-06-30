using System;
using System.Collections.Generic;
using System.Text;
using OhDotNetLib.Linq;
using Xunit;
using Shouldly;
namespace OhDotNetLib.Tests.Linq
{
    public class PredicateBuilderTest
    {
        #region Verify_PredicateBuilderTrueShouldBeWork

        [Fact]
        public void Verify_PredicateBuilderTrueShouldBeWork()
        {
            var True = PredicateBuilder.True<string>();
            True.Invoke("test").ShouldBe(true);
        }
        #endregion

        #region Verify_PredicateBuilderTrueShouldBeWork

        [Fact]
        public void Verify_PredicateBuilderParamtersShouldBeWork()
        {
            var paramList = PredicateBuilder.Paramters<Byte, Int32, Int64, Single, Decimal, DateTime, String, MyPredicateBuilderTestClass, Object>();
            for (int i = 0; i < paramList.Count; i++)
            {
                paramList[i].Name.ShouldBe("OhLinq_t" + (i + 1));
            }
        }
        #endregion
    }

    internal class MyPredicateBuilderTestClass
    {
    }
}
