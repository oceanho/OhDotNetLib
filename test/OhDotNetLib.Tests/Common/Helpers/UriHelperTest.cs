using System;
using System.Collections.Generic;
using System.Text;
using OhDotNetLib.Common.Helpers;

using Xunit;
using Shouldly;

namespace OhDotNetLib.Tests.Common.Helpers
{
    public class UriHelperTest
    {
        private const string FtpUri = "ftp://192.168.1.100:8000";
        private const string FtpDefaultPortUri = "ftp://192.168.1.100";
        private const string HttpUri = "http://www.oceanho.com:8081/about";
        private const string HttpDefaultPortUri = "http://api.oceanho.com/service/connect/oauth2?clientid=my-clientid";
        private const string HttpsUri = "https://www.oceanho.com:4443/about";
        private const string HttpsDefaultPortUri = "https://api.oceanho.com/service/connect/oauth2";

        private readonly static System.Text.RegularExpressions.Regex validUriRegex = new System.Text.RegularExpressions.Regex(@"^[a-z]{2,}[:][/]{2}.+[a-z0-9]$");

        #region Verify_GetSchemeHostShouldBeWork

        [Theory]
        [InlineData(FtpUri)]
        [InlineData(FtpDefaultPortUri)]
        [InlineData(HttpUri)]
        [InlineData(HttpDefaultPortUri)]
        [InlineData(HttpsUri)]
        [InlineData(HttpsDefaultPortUri)]
        public void Verify_GetSchemeHostShouldBeWork(object url)
        {
            var result = UriHelper.GetSchemeHost(new Uri(url.ToString()));
            validUriRegex.IsMatch(result).ShouldBe(true);
        }
        #endregion

        #region Verify_GetSchemeHostShouldBeWork

        [Fact]
        public void Verify_GetSchemeHostAndPathShouldBeWork()
        {
            var result = UriHelper.GetSchemeHostAndPath(new Uri(FtpUri));
            result.ShouldBe("ftp://192.168.1.100:8000/");

            var result2 = UriHelper.GetSchemeHostAndPath(new Uri(HttpDefaultPortUri));
            result2.ShouldBe("http://api.oceanho.com/service/connect/oauth2");
        }
        #endregion
    }
}
