using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using DbUtility;
using Models;
using MvcPager;

namespace Web.Areas.Mobile.Controllers
{
    public class AjaxController : Controller
    {
        LocationLogic locationLogic = new LocationLogic();
        DBContext dbContext = new DBContext();

        /// <summary>
        /// GET: /Mobile/Ajax/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn(string openID)
        {
            string sql = " selecT distinct provincename from dbo.THospital  order by provincename";

            DataTable table = dbContext.ExecuteDataTableSql(sql);// locationLogic.GetLocations(new Location() { areaType = 1 }, "", "sort", "desc").ToList();
            ViewBag.openID = openID;
            //if (memberLogic.GetMember(new Member() { OpenID = openID, IsDeleted = false }) != null)
            //{
            //    return Redirect("/mobile/ajax/welcome?openid=" + openID);
            //}
            return View();
        }

        public ActionResult SignUp(Member Formmember)
        {
            return View();
        }


        public ActionResult Welcome(string openID)
        {
            ViewBag.openID = openID;
            return View();
        }

        public ActionResult SendCode(string mobile)
        {
            string sms = Character.RandomString("num", 6);
            System.Web.HttpContext.Current.Session["SMS"] = sms;
            SMSHelper.UCPaasSend(24523, mobile, sms);
            return Content("1");
        }

        public ActionResult CheckMoible(string openID, string mobile, string pincode)
        {
            string SMS = System.Web.HttpContext.Current.Session["SMS"] != null ? System.Web.HttpContext.Current.Session["SMS"].ToString() : "";
            if (pincode.Trim() != SMS.ToString())
            {
                return Json(new { Status = false, Error = "验证码错误" });
            }
            if (string.IsNullOrWhiteSpace(openID) || string.IsNullOrWhiteSpace(mobile) || string.IsNullOrWhiteSpace(pincode))
            {
                return Json(new { Status = false, Error = "请填写所有信息" });
            }
            else
            {
                return Json(new { Status = true, Msg = "认证成功" });
            }
        }


        //=================================================获取===========================================
        //[OutputCache(Duration = 60)]
        //public ActionResult GetCity(string province)
        //{
        //    string sql = string.Format("selecT distinct cityname from dbo.THospital where provincename ='{0}'  order by cityname", province);

        //    IList<THospital> list = EntityReader.GetEntitiesForList<THospital>(dbContext.ExecuteDataTableSql(sql));
        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}


        //[OutputCache(Duration = 60)]
        //public ActionResult GetIsCountry(string province, string city)
        //{
        //    string sql = string.Format("selecT distinct  countiesnname from dbo.THospital  where provincename ='{0}' and  cityname='{1}' and  countiesnname is not null  ", province, city);

        //    IList<THospital> list = EntityReader.GetEntitiesForList<THospital>(dbContext.ExecuteDataTableSql(sql));
        //    if (list.Count > 0)
        //    {
        //        return Json(new { Status = true });
        //    }
        //    else
        //    {
        //        return Json(new { Status = false });
        //    }

        //}

       

        [OutputCache(Duration = 60)]
        public ActionResult City(string province)
        {
            IList<Location> list = locationLogic.GetLocations(new Location() { parentno = province });

            return Json(list, JsonRequestBehavior.AllowGet);
        }


    }
}
