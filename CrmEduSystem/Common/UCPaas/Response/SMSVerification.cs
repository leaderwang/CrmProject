
namespace jimaduo.SDK.UCPaas.Response
{
    public class SMSVerification
    {
        public _SMSVerificationresp resp { set; get; }
    }
    public class _SMSVerificationresp
    {
        /// <summary>
        /// 请求状态码，取值000000（成功）
        /// </summary>
        public string respCode { set; get; }
        /// <summary>
        /// 表示短信验证码发送失败的条数。注：批量发送时，才会返回该字段
        /// </summary>
        public string failure { set; get; }
        /// <summary>
        /// 发送短信信息
        /// </summary>
        public _templateSMS templateSMS { set; get; }
    }
    public class _templateSMS
    {
        /// <summary>
        /// 短信的创建时间
        /// </summary>
        public long createDate { set; get; }
        /// <summary>
        /// 短信标识符。一个由32个字符组成的短信唯一标识符
        /// </summary>
        public string smsId { set; get; }
    }
}
