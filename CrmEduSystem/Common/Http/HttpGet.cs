using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Common.Http
{
    public class HttpGet : HttpRequest
    {
        #region HttpGet
        public HttpGet(string uri)
        {
            base.Uri = uri;
            base.Method = HttpMethod.Get;
            base.ContentType = Constants.PostContentType;
        }
        #endregion

        #region ConstructUri
        protected override string ConstructUri()
        {
            var uri = base.Uri;
            if (null != Params)
            {
                uri += uri.IndexOf("?") < 0 ? "?" : "&";
                foreach (var item in Params)
                {
                    uri += string.Format("{0}={1}&", RFC3986Encoder.UrlEncode(item.Key), RFC3986Encoder.UrlEncode(item.Value));
                }
                uri = uri.TrimEnd('&');
            }
            return uri;
        }
        #endregion
    }
}
