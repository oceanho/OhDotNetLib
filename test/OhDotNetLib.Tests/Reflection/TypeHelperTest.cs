using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using OhDotNetLib.Reflection;

namespace OhDotNetLib.Tests.Reflection
{
    public class TypeHelperTest
    {
        #region Verify_GetGenericTypeUniqueNameShouldBeWork

        [Fact]
        public void Verify_GetGenericTypeUniqueNameShouldBeWork()
        {
            var name = TypeHelper.GetGenericTypeUniqueName(typeof(Int32));
            var name1 = TypeHelper.GetGenericTypeUniqueName(typeof(MyGenericTypeTestClass1<>));
            var name2 = TypeHelper.GetGenericTypeUniqueName(typeof(MyGenericTypeTestClass1<,>));
            var name3 = TypeHelper.GetGenericTypeUniqueName(typeof(MyGenericTypeTestClass1<,,,,,,,,,,>));
            var name4 = TypeHelper.GetGenericTypeUniqueName(typeof(MyGenericTypeTestClass1<,,,,,,,,,,>));

            Assert.NotSame(name1, name2);
            Assert.NotSame(name1, name3);
            Assert.NotSame(name2, name3);

             Assert.Same(name4, name4);
        }
        #endregion
    }

    internal class MyGenericTypeTestClass1<TTpye1>
    {

    }

    internal class MyGenericTypeTestClass1<TTpye1, TTpye2>
    {

    }

    internal class MyGenericTypeTestClass1<TTpye1, TTpye2, TTpye3>
    {

    }

    internal class MyGenericTypeTestClass1<TTpye1, TTpye2, TTpye3, TTpye4>
    {

    }
    internal class MyGenericTypeTestClass1<TTpye1, TTpye2, TTpye3, TTpye4, TTpye5, TTpye6, TTpye7, TTpye8, TTpye9, TTpye10, TTpye11>
    {

    }
}
