using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Common.Http
{
    internal class HttpPostJson : HttpPost
    {
        #region HttpPost
        public HttpPostJson(string uri)
            : base(uri)
        {
            base.Uri = uri;
            base.Method = HttpMethod.Post;
            base.ContentType = Constants.PostApplicationJson;
        }
        #endregion

    }
}
