using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Manager.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Manager/Base/
        /// <summary>
        /// site中开关控制
        /// </summary>
        public BaseController()
        {
            if (Lib.SiteHelper.Default.IsDeleloper != true)
            {
                var response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.BufferOutput = true;
                response.StatusCode = 403;
                response.Write("<!Doctype html><html xmlns=http://www.w3.org/1999/xhtml><head><meta http-equiv=Content-Type content=\"text/html;charset=utf-8\"><title>403页面禁止非法访问 </title><body>");
                response.Write("<h2>:( 此功能未开启，请联系本站管理员</h2>");
                response.Write("</body></html>");
                response.Flush();
                response.End();
            }
        }
    }
}
