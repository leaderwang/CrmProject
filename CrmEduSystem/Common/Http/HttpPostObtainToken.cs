using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Http
{
    public class HttpPostObtainToken : HttpPost
    {
        #region HttpPostObtainToken
        public HttpPostObtainToken(string uri)
            : base(uri)
        {
        }
        #endregion

        #region ConstructUri
        protected override string ConstructUri()
        {
            var uri = Uri;
            if (null != base.Params)
            {
                uri += "?";
                foreach (var item in base.Params)
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
