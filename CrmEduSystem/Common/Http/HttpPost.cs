using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Common.Http
{
    public class HttpPost : HttpRequest
    {
        #region HttpPost
        public HttpPost(string uri)
        {
            base.Uri = uri;
            base.Method = HttpMethod.Post;
            base.ContentType = Constants.PostContentType;
        }
        #endregion

        #region PostData
        public virtual string PostData { set; get; }
        #endregion

        #region WriteBody
        protected override void WriteBody(Stream reqStream)
        {
            var postData = PostData;
            if (string.IsNullOrEmpty(postData))
            {
                if (null != Params)
                {
                    var bodyBuilder = new StringBuilder();
                    foreach (var item in Params)
                    {
                        bodyBuilder.Append(string.Format("{0}={1}&", item.Key, item.Value));
                    }
                    postData = bodyBuilder.ToString().TrimEnd('&');
                }
            }

            if (!string.IsNullOrEmpty(postData))
            {
                var dataBytes = Encoding.UTF8.GetBytes(postData);
                reqStream.Write(dataBytes, 0, dataBytes.Length);
            }
        }
        #endregion

        #region AppendHeaders
        protected override void AppendHeaders(WebHeaderCollection headers)
        {
            headers.Add(HttpRequestHeader.ContentEncoding, "utf-8");
            base.AppendHeaders(headers);
        }
        #endregion
    }
}
