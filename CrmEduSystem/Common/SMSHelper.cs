﻿using System.IO;
using System.Net;
using System.Text;
namespace Common
{
    public class SMSHelper
    {
        /// <summary>
        /// 发送短信息
        /// </summary>
        /// <param name="mobile">手机</param>
        /// <param name="msg">内容</param>
        /// <param name="signature">签名</param>
        public static void Send(string mobile, string msg, string signature)
        {
            string result;
            byte[] buffer;
            string url = "http://sms.doctor120.cn/sms.asp?Cmd=SendSms";
            string postData = "mobile=" + mobile + "&msg=" + System.Web.HttpContext.Current.Server.UrlEncode(msg + "【" + signature + "】");
            buffer = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.KeepAlive = true;
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = buffer.Length;
            //req.CookieContainer = cookie; 
            req.Timeout = 50000;
            using (Stream reqst = req.GetRequestStream())
            {
                reqst.Write(buffer, 0, buffer.Length);
                reqst.Close();
            }
            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            {
                System.Threading.Thread.Sleep(3000);
                using (Stream resst = res.GetResponseStream())
                {
                    result = new StreamReader(resst, Encoding.Default).ReadToEnd();
                    resst.Close();
                }
            }
        }


        public static void UCPaasSend(int templateid, string to, string param)
        {
            // var templateid = (int)code;
            var call = new Common.UCPaas.Call("7351381734391d61d9bf5efdb8ffb86c", "d94469c4534c82422ca89c8fc2bb9be3");
            call.SendSMSVerification("bd94f04469ff4d2dbb52eb24e4cb5627", templateid.ToString(), to, param);
        }
    }
}
