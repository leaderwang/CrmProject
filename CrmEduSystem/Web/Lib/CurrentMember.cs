using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lib
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class CurrentMember
    {
        public const string Prefix = "CurrentMember-";

        #region 属性

        /// <summary>
        /// 登录用户IDer
        /// </summary>
        public static int ID
        {
            get
            {
                try
                {
                    if (System.Web.HttpContext.Current.Request.Cookies[Prefix + "ID"] != null
                        && !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Cookies[Prefix + "ID"].Value))
                    {
                        return int.Parse(System.Web.HttpContext.Current.Request.Cookies[Prefix + "ID"].Value);
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.Session[Prefix + "ID"] != null)
                            return Convert.ToInt32(System.Web.HttpContext.Current.Session[Prefix + "ID"]);
                        else
                            return 0;
                    }
                }
                catch { }
                return 0;

            }
        }

        /// <summary>
        /// 登录用户RoleID
        /// </summary>
        public static int RoleID
        {
            get
            {
                try
                {
                    if (System.Web.HttpContext.Current.Request.Cookies[Prefix + "RoleID"] != null
                        && !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Cookies[Prefix + "RoleID"].Value))
                    {
                        return int.Parse(System.Web.HttpContext.Current.Request.Cookies[Prefix + "RoleID"].Value);
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.Session[Prefix + "RoleID"] != null)
                            return int.Parse(System.Web.HttpContext.Current.Session[Prefix + "RoleID"].ToString());
                        return 0;
                    }
                }
                catch { }
                return 0;
            }
        }

        /// <summary>
        /// 登录用户CompanyID
        /// </summary>
        public static int CompanyID
        {
            get
            {
                try
                {
                    if (System.Web.HttpContext.Current.Request.Cookies[Prefix + "CompanyID"] != null
                        && !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Cookies[Prefix + "CompanyID"].Value))
                    {
                        return int.Parse(System.Web.HttpContext.Current.Request.Cookies[Prefix + "CompanyID"].Value);
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.Session[Prefix + "CompanyID"] != null)
                            return int.Parse(System.Web.HttpContext.Current.Session[Prefix + "CompanyID"].ToString());
                        return 0;
                    }
                }
                catch { }
                return 0;
            }
        }

        /// <summary>
        /// 登录用户UserName
        /// </summary>
        public static string UserName
        {
            get
            {
                try
                {
                    if (System.Web.HttpContext.Current.Request.Cookies[Prefix + "UserName"] != null
                        && !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Cookies[Prefix + "UserName"].Value))
                    {
                        return Common.Character.DecryptBase64(System.Web.HttpContext.Current.Request.Cookies[Prefix + "UserName"].Value);
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.Session[Prefix + "UserName"] != null)
                            return System.Web.HttpContext.Current.Session[Prefix + "UserName"].ToString();
                        else
                            return "";
                    }
                }
                catch
                {

                }
                return "";
            }
        }

        /// <summary>
        /// 登录用户RealName
        /// </summary>
        public static string RealName
        {
            get
            {
                try
                {
                    if (System.Web.HttpContext.Current.Request.Cookies[Prefix + "RealName"] != null
                        && !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Cookies[Prefix + "RealName"].Value))
                    {
                        return Common.Character.DecryptBase64(System.Web.HttpContext.Current.Request.Cookies[Prefix + "RealName"].Value);
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.Session[Prefix + "RealName"] != null)
                            return System.Web.HttpContext.Current.Session[Prefix + "RealName"].ToString();
                        else
                            return "";
                    }
                }
                catch
                {

                }
                return "";
            }
        }

        /// <summary>
        /// 登录用户Member对象
        /// </summary>
        public static Member Member
        {
            get
            {
                try
                {
                    MemberLogic userlogic = new MemberLogic();
                    if (ID > 0)
                    {
                        if (System.Web.HttpContext.Current.Session[Prefix + "Member"] != null)
                            return System.Web.HttpContext.Current.Session[Prefix + "Member"] as Member;
                        else
                        {
                            Member _member = userlogic.GetMember(new Member { ID = ID });
                            System.Web.HttpContext.Current.Session[Prefix + "Member"] = _member;
                            if (_member == null || _member.ID < 0)
                            {
                                System.Web.HttpContext.Current.Response.Redirect("/admin/Account/LogOut");
                            }
                            return _member;
                        }
                    }
                    else
                        return new Member();
                }
                catch { }
                return new Member();
            }
        }

        public static Role Role
        {
            get
            {
                try
                {
                    Role _role = new RoleLogic().GetRole(CurrentMember.RoleID);
                    if (_role == null || _role.ID < 0)
                    {
                        System.Web.HttpContext.Current.Response.Redirect("/admin/Account/LogOut");
                    }
                    return _role ?? new Role();
                }
                catch { }
                return new Role();
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 登录
        /// </summary>
        public static bool LogOn(string username, string password, bool auto, out string message)
        {
            MemberLogic userlogic = new MemberLogic();
            Member user = new Member();
            bool flag = true;
            message = "";
            user = userlogic.GetMember(new Member { UserName = username, Password = Character.EncrytPassword(password) });
            if (user == null)
            {
                flag = false;
                message = "登录失败，账户信息错误";
            }
            else
            {
                if (auto)
                {
                    int expiresDate = 7;

                    System.Web.HttpCookie cookie = new System.Web.HttpCookie(Prefix + "ID");
                    cookie.Value = user.ID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(expiresDate);
                    System.Web.HttpContext.Current.Response.AppendCookie(cookie);

                    System.Web.HttpCookie cookie2 = new System.Web.HttpCookie(Prefix + "RoleID");
                    cookie2.Value = user.RoleID.ToString();
                    cookie2.Expires = DateTime.Now.AddDays(expiresDate);
                    System.Web.HttpContext.Current.Response.AppendCookie(cookie2);

                    System.Web.HttpCookie cookie3 = new System.Web.HttpCookie(Prefix + "UserName");
                    cookie3.Value = Common.Character.EncryptBase64(user.UserName.ToString());
                    cookie3.Expires = DateTime.Now.AddDays(expiresDate);
                    System.Web.HttpContext.Current.Response.AppendCookie(cookie3);

                    System.Web.HttpCookie cookie4 = new System.Web.HttpCookie(Prefix + "CompanyID");
                    cookie4.Value = user.CompanyID.ToString();
                    cookie4.Expires = DateTime.Now.AddDays(expiresDate);
                    System.Web.HttpContext.Current.Response.AppendCookie(cookie4);


                    System.Web.HttpCookie cookie5 = new System.Web.HttpCookie(Prefix + "RealName");
                    cookie5.Value = user.RealName.ToString();
                    cookie5.Expires = DateTime.Now.AddDays(expiresDate);
                    System.Web.HttpContext.Current.Response.AppendCookie(cookie5);
                }
                else
                {
                    System.Web.HttpContext.Current.Session[Prefix + "ID"] = user.ID;
                    System.Web.HttpContext.Current.Session[Prefix + "UserName"] = user.UserName;
                    System.Web.HttpContext.Current.Session[Prefix + "RealName"] = user.RealName;
                    System.Web.HttpContext.Current.Session[Prefix + "RoleID"] = user.RoleID;
                    System.Web.HttpContext.Current.Session[Prefix + "CompanyID"] = user.CompanyID;

                    System.Web.HttpContext.Current.Session[Prefix + "Member"] = user;
                }

                message = "登录成功，欢迎回来" + user.UserName;
            }
            return flag;
        }
        /// <summary>
        /// 注销
        /// </summary>
        public static void LogOut()
        {
            //清除Cookie
            System.Web.HttpCookie cookie = new System.Web.HttpCookie(Prefix + "ID");
            cookie.Expires = DateTime.Now.AddSeconds(-1);
            System.Web.HttpContext.Current.Response.AppendCookie(cookie);

            System.Web.HttpCookie cookie2 = new System.Web.HttpCookie(Prefix + "RoleID");
            cookie2.Expires = DateTime.Now.AddSeconds(-1);
            System.Web.HttpContext.Current.Response.AppendCookie(cookie2);

            System.Web.HttpCookie cookie3 = new System.Web.HttpCookie(Prefix + "UserName");
            cookie3.Expires = DateTime.Now.AddSeconds(-1);
            System.Web.HttpContext.Current.Response.AppendCookie(cookie3);

            System.Web.HttpCookie cookie4 = new System.Web.HttpCookie(Prefix + "CompanyID");
            cookie4.Expires = DateTime.Now.AddSeconds(-1);
            System.Web.HttpContext.Current.Response.AppendCookie(cookie4);

            System.Web.HttpCookie cookie5 = new System.Web.HttpCookie(Prefix + "RealName");
            cookie5.Expires = DateTime.Now.AddSeconds(-1);
            System.Web.HttpContext.Current.Response.AppendCookie(cookie5);

            //删除Session
            System.Web.HttpContext.Current.Session.Clear();
        }
        /// <summary>
        /// 权限当前用户访问权限
        /// </summary>
        public static void CheckAccess()
        {
            if (ID == 0)//没有登陆
            {
                System.Web.HttpContext.Current.Response.Redirect("/account/logon?url=" + Microsoft.JScript.GlobalObject.escape(Common.UrlHelper.CurrentUrl));
                return;
            }
        }
        #endregion
    }
}