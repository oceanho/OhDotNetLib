using System;
using System.Collections.Generic;
using System.Text;

namespace OhDotNetLib.Common.Helpers
{
    public static class UriHelper
    {
        /// <summary>
        /// 获取指定uri的主机域名，返回结果格式如：http://www.oceanho.com / http://www.oceanho.com:8081 / https://api.oceanho.com
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string GetSchemeHost(Uri uri)
        {
            return $"{uri.Scheme}://{uri.Host}{(uri.IsDefaultPort ? "" : $":{uri.Port}")}";
        }

        /// <summary>
        /// 获取指定uri的主机域名+请求路径，返回结果格式如：http://www.oceanho.com/ / http://www.oceanho.com/home/about / https://api.oceanho.com/service/connect/ouath2
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string GetSchemeHostAndPath(Uri uri)
        {
            return $"{GetSchemeHost(uri)}{uri.AbsolutePath}";
        }
    }
}
