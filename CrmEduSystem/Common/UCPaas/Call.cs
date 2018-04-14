using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;


namespace Common.UCPaas
{
    /// <summary>
    /// 云之讯融合通讯开放平台
    /// </summary>
    public class Call
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        const string _restAddress = "https://api.ucpaas.com";
        /// <summary>
        /// 服务器api版本
        /// </summary>
        const string _softVer = "2014-06-30";
        /// <summary>
        /// appid
        /// </summary>
        string _accountsid { set; get; }
        /// <summary>
        /// authtoken
        /// </summary>
        string _authtoken { set; get; }
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="appid"></param>
        public Call(string accountsid, string authtoken)
        {
            this._accountsid = accountsid;
            this._authtoken = authtoken;
        }

        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="templateid"></param>
        /// <param name="to"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public jimaduo.SDK.UCPaas.Response.SMSVerification SendSMSVerification(string appid, string templateid, string to, string param)
        {
            if (string.IsNullOrEmpty(templateid) || string.IsNullOrEmpty(to)) return null;

            // 签名
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            string sigstr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this._accountsid + this._authtoken + date, "MD5");

            var url = _restAddress + string.Format("/{0}/Accounts/{1}/Messages/templateSMS.json?sig={2}", _softVer, this._accountsid, sigstr);

            var req = new Http.HttpPostJson(url);
            //验证
            Encoding myEncoding = Encoding.GetEncoding("utf-8");
            byte[] myByte = myEncoding.GetBytes(this._accountsid + ":" + date);
            string authStr = Convert.ToBase64String(myByte);
            req.Headers = new Dictionary<string, string> { { "Authorization", authStr } };

            // 构建Body
            StringBuilder PostData = new StringBuilder();
            PostData.Append("{");
            PostData.Append("\"templateSMS\":{");
            PostData.Append("\"appId\":\"").Append(appid).Append("\"");
            PostData.Append(",\"templateId\":\"").Append(templateid).Append("\"");
            PostData.Append(",\"to\":\"").Append(to).Append("\"");
            PostData.Append(",\"param\":\"").Append(param).Append("\"");
            PostData.Append("}}");

            req.PostData = PostData.ToString();
            var data = req.Request();

            return (new JavaScriptSerializer()).Deserialize<jimaduo.SDK.UCPaas.Response.SMSVerification>(data);

        }
    }
}
