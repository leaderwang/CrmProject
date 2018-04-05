using Common;
using DbUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Admin/Report/ExportUser

        DBContext db = new DBContext();

        ///// <summary>
        ///// 同步数据
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Index()
        //{
        //    var strCon = System.Configuration.ConfigurationManager.AppSettings["connectionString1"].ToString();
        //    DBContext dbContext = new DBContext(strCon);
        //    var strSql = string.Format(@"select openid,[status] from wx_users where projectkey='7ce2048d61ad391a'");
        //    var list = dbContext.QueryForListSql<wx_users>(strSql);

        //    return View();
        //}

        /// <summary>
        /// 导出用户注册记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportUser()
        {
            try
            {
                //注册用户数
                var strSql1 = string.Format(@"select a.*,b.unsubscribetime from (selecT ID,RealName,Mobile,Address,OpenID,Province,City,Country,Hospital,Department,CreateDate 
                                            from dbo.Member where OpenID like '%oO2%' and  OpenID is not null and OpenID in ( select OpenID  from   wx where [status]=1)
                                            )as a left join wx b on a.OpenID=b.openid  ORDER BY a.CreateDate ");

                //取消注册用户数
                var strSql2 = string.Format(@"select a.*,b.unsubscribetime from (selecT ID,RealName,Mobile,Address,OpenID,Province,City,Country,Hospital,Department,CreateDate 
                                            from dbo.Member where OpenID like '%oO2%' and  OpenID is not null and  OpenID not  in ( select OpenID  from   wx where [status]=1)
                                            )as a left join wx b on a.OpenID=b.openid  ORDER BY a.CreateDate");

                //注册人数中有哪些是目标客户
                var strSql3 = string.Format(@"select a.*,b.unsubscribetime from (selecT ID,RealName,Mobile,Address,OpenID,Province,City,Country,Hospital,Department,CreateDate 
                                            from dbo.Member where OpenID like '%oO2%' and  OpenID is not null and  OpenID in ( select OpenID  from   wx where [status]=1) 
                                            and  Mobile in (selecT mobile  from dbo.UserData where LEN(mobile)=11 and mobile is not null)
                                            )as a left join wx b on a.OpenID=b.openid  ORDER BY a.CreateDate");

                //取消注册的用户中有哪些是目标客户
                var strSql4 = string.Format(@"select a.*,b.unsubscribetime from (selecT ID,RealName,Mobile,Address,OpenID,Province,City,Country,Hospital,Department,CreateDate 
                                            from dbo.Member where OpenID like '%oO2%' and  OpenID is not null and  OpenID not  in ( select OpenID  from   wx where [status]=1) 
                                            and  Mobile in (selecT mobile  from dbo.UserData where LEN(mobile)=11 and mobile is not null)
                                            )as a left join wx b on a.OpenID=b.openid  ORDER BY a.CreateDate");

                var dt1 = db.ExecuteDataTableSql(strSql1);
                var dt2 = db.ExecuteDataTableSql(strSql2);
                var dt3 = db.ExecuteDataTableSql(strSql3);
                var dt4 = db.ExecuteDataTableSql(strSql4);

                Dictionary<string, System.Data.DataTable> list = new Dictionary<string, System.Data.DataTable>();

                list.Add("注册用户数", dt1);
                list.Add("取消注册用户数", dt2);
                list.Add("注册人数中有哪些是目标客户", dt3);
                list.Add("取消注册的用户中有哪些是目标客户", dt4);

                OpenXmlExcelHelper.ExportByWebList(list, DateTime.Now.ToString("用户注册记录" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".xlsx");
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.Write("导出失败：" + ex.Message);
                Response.Write("<script>alert(\"导出失败：" + ex.Message + "\"); history.back();</script>");
                Response.Flush();
                Response.End();
            }
            return Content(string.Empty);
        }

        /// <summary>
        /// 导出积分兑换记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportGift()
        {
            try
            {
                var strSql = string.Format(@"selecT CreateDate 兑换时间,OpenID,GiftName 礼品名称,ExchangeScore 消耗积分,RealName 收件人,Mobile 电话,Province 省份,City 城市,
                                         Address 地址 from dbo.GiftLog  order by CreateDate desc");
                var dt = db.ExecuteDataTableSql(strSql);

                OpenXmlExcelHelper.ExportByWeb(dt, DateTime.Now.ToString("积分兑换记录" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".xlsx", "sheet1");
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.Write("导出失败：" + ex.Message);
                Response.Write("<script>alert(\"导出失败：" + ex.Message + "\"); history.back();</script>");
                Response.Flush();
                Response.End();
            }
            return Content(string.Empty);
        }


        /// <summary>
        /// 导出用户表记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportMember()
        {
            try
            {
                var strSql = string.Format(@"SELECT id, OpenID , RealName '真实姓名',nickname '昵称',Mobile '号码', Province '省', City '市', PinCode '验证码', Hospital '医院', Department '科室', Address '地址', 
                                             CreateDate '创建时间',  CASE WHEN IsDeleted=1 THEN '1' WHEN IsDeleted=0 THEN '0' END '是否删除'
                                             FROM dbo.Member where OpenID like '%oO2%' and  OpenID is not null  ORDER BY CreateDate DESC");

                var dt = db.ExecuteDataTableSql(strSql);

                OpenXmlExcelHelper.ExportByWeb(dt, DateTime.Now.ToString("用户列表" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".xlsx", "sheet1");
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.Write("导出失败：" + ex.Message);
                Response.Write("<script>alert(\"导出失败：" + ex.Message + "\"); history.back();</script>");
                Response.Flush();
                Response.End();
            }
            return Content(string.Empty);
        }
    }
}
