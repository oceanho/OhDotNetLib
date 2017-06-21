using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Shouldly;

namespace OhDotNetLib.Tests.Extension
{
    using OhDotNetLib.Extension;

    public class StringExtensionOfUrlWithBase64
    {
        [Theory]
        [InlineData("ABC")]
        [InlineData("123456")]
        [InlineData("ABC123456")]
        [InlineData("ABC123456中文")]
        public void Base64_BaseOperatorShouldBeWork(string str)
        {
            var _str = str.ToBase64Str();
            _str.FromBase64Str();

            var str2 = _str.ToReplacedUrlSpecialCharacter();

            str2.ShouldNotContain("+");
            str2.ShouldNotContain("/");
            str2.ShouldNotContain("=");

            var str3 = str2.FromReplacedUrlSpecialCharacter();
        }
    }
}
