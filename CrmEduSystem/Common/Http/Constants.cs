using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Http
{
    internal static class Constants
    {

        internal const string PostContentType = "application/x-www-form-urlencoded";

        internal const string PostMultiPartContentType = "multipart/form-data;boundary={0}";

        internal const string PostApplicationJson = "application/json;charset=utf-8";
    }
}
