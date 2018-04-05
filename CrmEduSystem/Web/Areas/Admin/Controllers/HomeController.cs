using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using Lib;
using Models;


namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewData["optionNames"] = new List<string>();
            if (Lib.SiteHelper.Default.IsValidePermission == true)
            {
                if (CurrentMember.ID > 0)
                {
                    //读取菜单
                    if (CurrentMember.RoleID == 1) return View();
                    PermissionHelper permission = new PermissionHelper();
                    var plts = permission.PermissionDatas.Where(b => b.RID == CurrentMember.RoleID).ToList();
                    List<string> optionNames = new List<string>();
                    if (plts != null && plts.Count > 0)
                    {
                        foreach (var item in plts)
                        {
                            try
                            {
                                if (item.HasPermission == true)
                                {
                                    var mid = new PermissionMapLogic().GetPermissionMap(new PermissionMap() { ID = item.PID, Name = "菜单" }).MID;
                                    optionNames.Add(new MenuLogic().GetMenu(new Menu() { ID = mid }).Name);
                                }
                            }
                            catch { }
                        }
                    }
                    ViewData["optionNames"] = optionNames;
                }
            }
            return View();
        }
    }
}
