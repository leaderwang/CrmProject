using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using DbUtility;

using Models;

namespace Web.Areas.Mobile.Controllers
{
    [LoginFlagAttribute]
    public class AccountController : Controller
    {
        MemberLogic memberLogic = new MemberLogic();
        DBContext db = new DBContext();
        LocationLogic locationLogic = new LocationLogic();
        ArticleLogic articleLogic = new ArticleLogic();
        //
        // GET: /Mobile/Account/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Rule()
        {
            ViewBag.Rule = articleLogic.GetArticle(new Article() { ID = 147 }).Content;
            return View();
        }

        /// <summary>
        /// 积分兑换
        /// </summary>
        /// <returns></returns>
        public ActionResult Exchange(string openID)
        {
            Member member = new Member();// memberLogic.GetMember(new Member() { OpenID = openID, IsDeleted = false });
            ViewBag.Member = member;
            ViewBag.openID = openID;
            //临时调用
            string sql = string.Format("selecT SUM( ISNULL(score,0))total from dbo.UserLog where OpenID = '{0}'", openID);
            // ViewBag.Total = db.ExecuteScalarSql(sql);
            //  ViewBag.Total = member.Score;
            //礼品
            // ViewBag.Gift = giftLogic.GetGifts(new Gift() { IsDeleted = false });
            var strSql = string.Format(@"SELECT  ID, CreateUserID, LastUpdateUserID, CreateDate, LastUpdateDate, IsDeleted, Sort, Name, Score, 
                                         Department, Introduce,datepart(quarter,GETDATE()) QuarterId FROM Gift  WHERE IsDeleted='false'");
           
            return View();
        }


        public ActionResult ExchangeInfo(string openID, string giftID)
        {

            Member member = new Member();// memberLogic.GetMember(new Member() { OpenID = openID, IsDeleted = false });

            return View();
        }

        public ActionResult About()
        {

            return View();
        }
    }
}
