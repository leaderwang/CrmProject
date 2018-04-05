using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using DbUtility;
using Common;
using Common.UCPaas;


namespace Models
{
    public partial class MemberLogic
    {
        ArticleReadLogLogic articleReadLog = new ArticleReadLogLogic();
        DBContext dbContext = new DBContext();
        public bool GetReadLog(ArticleReadLog log)
        {
            if (articleReadLog.GetArticleReadLogs(new ArticleReadLog() { AID = log.AID, OpenID = log.OpenID }).Count == 0)
            {
                if (articleReadLog.Add(log))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        //public bool GetHeader(Member member)
        //{

        //    if (!string.IsNullOrWhiteSpace(member.OpenID))
        //    {
        //        //获取token
        //        /*
        //        Token token = new Token();
        //        token.access_token = Call.ca("wxbb9a87515fc7ef6f", "cc0d6070dbcce1bbdd759a068b649838").access_token;
        //        var userInfo = new Call(token.access_token).GetUserInfo(member.OpenID, true);
        //        */
        //        Call call = new Call();
        //        var userInfo = call.GetUserInfo(member.OpenID);
        //        member.NickName = userInfo.nickname;
        //        member.Avatar = userInfo.headimgurl;
        //        member.LastUpdateDate = DateTime.Now;
        //        Update(member);

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
