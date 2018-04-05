using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

using Models;


namespace Web.Areas.Mobile.Controllers
{
    /// <summary>
    /// 验证用户是否登录
    /// </summary>
    public class LoginFlagAttribute : ActionFilterAttribute
    {

        bool _valide;

        public LoginFlagAttribute()
        {
            _valide = true;
        }

        public LoginFlagAttribute(bool valide)
        {
            _valide = valide;
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            try
            {
                string openID = filterContext.HttpContext.Request["openid"].ToString();
                MemberLogic memberLogic = new MemberLogic();

                //string backurl = HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.LocalPath.ToLower());
                //W_UserAuth userAuth = userAuthLgc.GetW_UserAuth(new W_UserAuth() { OpenID = openID });

                if (!string.IsNullOrWhiteSpace(openID))
                {
                    openID = Character.NoHTML(openID);

                    //Member member = memberLogic.GetMember(new Member() { OpenID = openID });
                    //if ((member == null) && _valide) //(CurrentUser.Saler == null || CurrentUser.Saler.ID < 1) &&
                    //{
                    //    filterContext.HttpContext.Response.Redirect("http://m.vhdong.com/s/83117dae14563ff8");
                    //}
                }
                else
                {
                    filterContext.HttpContext.Response.Redirect("http://m.vhdong.com/s/83117dae14563ff8");
                }

            }
            catch
            {
                filterContext.HttpContext.Response.Redirect("http://m.vhdong.com/s/83117dae14563ff8");
            }
        }
    }
}