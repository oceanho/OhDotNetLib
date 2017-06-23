using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Shouldly;
using OhDotNetLib.Reflection;
using System.Linq;

namespace OhDotNetLib.Tests.Reflection
{
    public class ReflectionHelperTest
    {
        #region Verify_IsPrimitiveShouldBeWork

        [Fact]
        public void Verify_IsPrimitiveShouldBeWork()
        {
            ReflectionHelper.IsPrimitive(-1).ShouldBe(true);
            ReflectionHelper.IsPrimitive(32).ShouldBe(true);
            ReflectionHelper.IsPrimitive("test").ShouldBe(true);

            ReflectionHelper.IsPrimitive(typeof(int)).ShouldBe(true);
            ReflectionHelper.IsPrimitive(typeof(Int32)).ShouldBe(true);
            ReflectionHelper.IsPrimitive(typeof(long)).ShouldBe(true);
            ReflectionHelper.IsPrimitive(typeof(Int64)).ShouldBe(true);
            ReflectionHelper.IsPrimitive(typeof(string)).ShouldBe(true);
            ReflectionHelper.IsPrimitive(typeof(String)).ShouldBe(true);

            ReflectionHelper.IsPrimitive(32.00F).ShouldBe(true);
            ReflectionHelper.IsPrimitive(typeof(float)).ShouldBe(true);
            ReflectionHelper.IsPrimitive(32.00D).ShouldBe(true);
            ReflectionHelper.IsPrimitive(typeof(double)).ShouldBe(true);

            ReflectionHelper.IsPrimitive(32.00M).ShouldBe(false);
            ReflectionHelper.IsPrimitive(DateTime.Now).ShouldBe(false);
            ReflectionHelper.IsPrimitive(new MyTestClass()).ShouldBe(false);
            ReflectionHelper.IsPrimitive(typeof(MyTestClass)).ShouldBe(false);
        }
        #endregion

        #region Verify_GetPropertiesShouldBeWork

        [Fact]
        public void Verify_GetPropertiesShouldBeWork()
        {
            var mytest = new MyTestClass();
            var properties = ReflectionHelper.GetProperties(mytest);
            properties.Count().ShouldBe(4);

            var mytest2 = new MyTestClass
            {
                Id = 10000,
                Name = "OceanHo",
                Gender = Gender.Man,
                MyTestProp = new MyTestProperty()
            };

            foreach (var property in properties)
            {
                var val = property.GetValue(mytest2, null);
                val.ShouldNotBe(0);
                val.ShouldNotBe(string.Empty);
            }

            var prop1 = ReflectionHelper.GetProperties(mytest, p => p.PropertyType == typeof(int));
            prop1.Count().ShouldBe(1);
            prop1.FirstOrDefault().Name.ShouldBe("Id");

            var prop2 = ReflectionHelper.GetProperties(mytest, p => p.PropertyType == typeof(string));
            prop2.Count().ShouldBe(1);
            prop2.FirstOrDefault().Name.ShouldBe("Name");

            var prop3 = ReflectionHelper.GetProperties(mytest, p => p.PropertyType == typeof(Gender));
            prop3.Count().ShouldBe(1);
            prop3.FirstOrDefault().Name.ShouldBe("Gender");

            var prop4 = ReflectionHelper.GetProperties(mytest, p => ReflectionHelper.IsPrimitive(p.PropertyType));
            prop4.Count().ShouldBe(2);
        }
        #endregion

        #region Verify_GetCanAssignabledTypePropertiesShouldBeWork

        [Fact]
        public void Verify_GetCanAssignabledTypePropertiesShouldBeWork()
        {
            var mytest = new MyTestClass();
            var properties = ReflectionHelper.GetCanAssignabledTypeProperties(mytest, typeof(IMyTestProperty));
            properties.Count().ShouldBe(1);
            properties.FirstOrDefault().Name.ShouldBe("MyTestProp");
            properties.FirstOrDefault().PropertyType.ShouldBe(typeof(MyTestProperty));
        }
        #endregion
    }

    #region internal object(Gender/MyTestClass)

    internal enum Gender
    {
        Man = 1,
        Woman = 2,
        ManAndWoman = 3
    }

    interface IMyTestProperty
    {
    }
    class MyTestProperty : IMyTestProperty
    {
    }
    internal class MyTestClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public MyTestProperty MyTestProp { get; set; }
    }
    #endregion
}
