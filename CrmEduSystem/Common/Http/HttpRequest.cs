using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Common.Http
{
    public class HttpRequest
    {
        #region Params
        /// <summary>
        /// 参数
        /// </summary>
        public Dictionary<string, string> Params = new Dictionary<string, string>();
        #endregion

        #region Timeout
        public int Timeout { set; get; }
        #endregion

        #region Uri
        /// <summary>
        /// Url地址
        /// </summary>
        protected virtual string Uri { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// 提交方式
        /// </summary>
        protected virtual string Method { get; set; }
        #endregion

        #region ContentType
        /// <summary>
        /// 连接类型
        /// </summary>
        protected virtual string ContentType { get; set; }
        #endregion

        #region Params
        /// <summary>
        /// 请求协议标头
        /// </summary>
        public Dictionary<string, string> Headers { set; get; }// = new Dictionary<string, string>();
        #endregion

        #region RemoteCertificateValidate
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // trust any certificate!!!
            System.Console.WriteLine("Warning, trust any certificate");
            //为了通过证书验证，总是返回true
            return true;
        }
        #endregion

        #region HttpRequest
        public HttpRequest()
        {
            //验证服务器证书回调自动验证
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
        }
        #endregion

        public WebResponse webResponse { set; get; }


        #region WebRequest
        private HttpWebRequest WebRequest()
        {
            HttpWebRequest req = HttpWebRequest.Create(ConstructUri()) as HttpWebRequest;
            if (!Timeout.Equals(0))
            {
                req.Timeout = Timeout;
            }
            AppendHeaders(req.Headers);
            if (!string.IsNullOrEmpty(Method))
                req.Method = Method;
            if (!string.IsNullOrEmpty(ContentType))
                req.ContentType = ContentType;

            PrepareRequest(req);
            if (req.Method == HttpMethod.Post)
            {
                using (var reqStream = req.GetRequestStream())
                {
                    WriteBody(reqStream);
                }
            }
            return req;
        }
        #endregion

        #region Request
        public virtual String Request()
        {
            //微信HTTPS,指定证书协议
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            HttpWebRequest req = WebRequest();
            if (!Timeout.Equals(0))
            {
                req.Timeout = Timeout;
            }
            //WebResponse resp = null;
            try
            {
                webResponse = req.GetResponse();
                return RetrieveResponse(webResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                webResponse.Close();
            }
        }
        #endregion

        #region RequestStream
        public virtual System.IO.Stream RequestStream()
        {
            HttpWebRequest req = WebRequest();

            if (!Timeout.Equals(0))
            {
                req.Timeout = Timeout;
            }
            try
            {
                webResponse = req.GetResponse();
                var io = RetrieveResponseStream(webResponse);
                return io;
            }
            catch (Exception ex)
            {
                throw new Exception("RequestStream:" + ex.Message);
                //return null;
            }
            finally
            {
                //WebResponse.Close();
            }

        }
        #endregion

        #region ConstructUri
        protected virtual string ConstructUri()
        {
            return Uri;
        }
        #endregion

        #region AppendHeaders
        /// <summary>
        /// 添加请求协议标头
        /// </summary>
        /// <param name="headers"></param>
        protected virtual void AppendHeaders(WebHeaderCollection headers)
        {
            if (Headers != null)
            {
                foreach (var h in Headers)
                {
                    headers.Add(h.Key, h.Value);
                }
            }
            // Nothing to do.
        }
        #endregion

        #region WriteBody
        protected virtual void WriteBody(Stream reqStream)
        {
            // Nothing to do. 
        }
        #endregion

        #region PrepareRequest
        protected virtual void PrepareRequest(HttpWebRequest webRequest)
        {
        }
        #endregion

        #region RetrieveResponse
        private string RetrieveResponse(WebResponse webResponse)
        {
            var respContent = string.Empty;
            var respStream = webResponse.GetResponseStream();
            using (StreamReader reader = new StreamReader(respStream, Encoding.UTF8))
            {
                respContent = reader.ReadToEnd();
            }
            return respContent;
        }
        #endregion

        #region RetrieveResponseStream
        private System.IO.Stream RetrieveResponseStream(WebResponse webResponse)
        {
            var respStream = webResponse.GetResponseStream();
            return respStream;
        }
        #endregion

        #region GetConstructedUri
        public string GetConstructedUri()
        {
            return ConstructUri();
        }
        #endregion

    }
}
