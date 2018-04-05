using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Models;

namespace Web.Areas.Admin.Controllers
{
    public class ConfigController : BaseController
    {
        #region 站点配置
        public ActionResult Site()
        {
            try
            {
                SiteLogic ml = new SiteLogic();

                List<Site> list = ml.GetSites();
                Site obj = (list.Count > 0 ? list.First() : new Site());
                return View(obj);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Site(FormCollection formCollection)
        {
            try
            {
                bool result = false;
                SiteLogic ml = new SiteLogic();
                List<Site> list = ml.GetSites();
                Site obj = new Site();
                if (list.Count > 0)
                {
                    obj.LastUpdateDate = DateTime.Now;

                    obj.LastUpdateUserID = ID;

                    UpdateModel(obj);
                    if (obj.IsValidePermission==null || obj.IsValidePermission == false)
                    {
                        obj.IsFromFile = null;
                    }
                    result = ml.Update(obj);
                }
                else
                {
                    obj = new Site() { CreateDate = DateTime.Now, CreateUserID = ID, IsDeleted = false };

                    UpdateModel(obj);

                    result = ml.Add(obj);
                }

                return result ? Content(ContentIcon.Succeed + "|保存成功") : Content(ContentIcon.Error + "|保存失败");
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }


        /// <summary>
        /// 设置开发人员选项开关
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetIsDeleloper(bool val)
        {
            string result = "";
            try
            {
                var site = Lib.SiteHelper.Default;
                site.IsDeleloper = val;
                SiteLogic sl = new SiteLogic();
                sl.Update(site);
                result = "ok";
            }
            catch { }
            return Content(result);
        }
        #endregion

        #region 邮箱配置

        public ActionResult Mail()
        {
            try
            {
                MailSettingLogic ml = new MailSettingLogic();

                List<MailSetting> list = ml.GetMailSettings();
                MailSetting obj = (list.Count > 0 ? list.First() : new MailSetting());
                return View(obj);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Mail(FormCollection formCollection)
        {
            try
            {
                bool result = false;
                MailSettingLogic ml = new MailSettingLogic();
                List<MailSetting> list = ml.GetMailSettings();
                MailSetting obj = new MailSetting();
                if (list.Count > 0)
                {
                    obj.LastUpdateDate = DateTime.Now;

                    obj.LastUpdateUserID = ID;

                    UpdateModel(obj);

                    result = ml.Update(obj);
                }
                else
                {
                    obj = new MailSetting() { CreateDate = DateTime.Now, CreateUserID = ID, IsDeleted = false };

                    UpdateModel(obj);

                    result = ml.Add(obj);
                }

                return result ? Content(ContentIcon.Succeed + "|保存成功") : Content(ContentIcon.Error + "|保存失败");
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }
        #endregion

        #region 工作流
        public ActionResult Work()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Work(FormCollection formCollection)
        {
            try
            {
                //会议状态|角色|界面|按钮ID
                string roles = formCollection["roles"];
                if (!string.IsNullOrEmpty(roles))
                {
                    string[] arr_roles = roles.Split(',');
                    StringBuilder s = new StringBuilder();
                    s.Append("truncate table TRoleRelation;");
                    foreach (string str in arr_roles)
                    {
                        string[] arr_str=str.Split('|');
                        s.Append(@"insert into TRoleRelation(MeettingStatus, RoleID, PageType, StatusBtnID, IsChecked, CreateUserID, CreateDate, IsDeleted)
values(" + arr_str[0] + "," + arr_str[1] + "," + arr_str[2] + "," + arr_str[3] + ",1,"+ID+",getdate(),0);");
                    }
                    new DbUtility.DBContext().ExecuteScalarSql(s.ToString());
                }
                return Content(ContentIcon.Succeed + "|保存成功");
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }
        #endregion
    }
}
