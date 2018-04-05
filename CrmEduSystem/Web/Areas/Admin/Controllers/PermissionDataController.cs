﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using MvcPager;
using DbUtility;
using System.Web.UI;
using System.Data;
using Lib;

namespace Web.Areas.Admin.Controllers
{
    public class PermissionDataController : BaseController
    {

        public ActionResult Index(int? pageIndex, int? pageSize, PermissionData entity)
        {
            try
            {
                PermissionDataLogic ml = new PermissionDataLogic();
                entity.IsDeleted = false;
                PagedList<PermissionData> page = ml.GetPermissionDatas(entity, pageIndex ?? PageIndex, pageSize ?? PageSize, Order, By);

                IList<PermissionData> objs = page;

                if (Request.IsAjaxRequest())

                    return PartialView("_Index", objs);

                return View(objs);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        public ActionResult Create()
        {
            return View(new PermissionData());
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            try
            {
                PermissionDataLogic ml = new PermissionDataLogic();

                PermissionData obj = new PermissionData() { CreateDate = DateTime.Now, CreateUserID = ID, IsDeleted = false };

                UpdateModel(obj);

                bool result = ml.Add(obj);

                return result ? Content(ContentIcon.Succeed + "|操作成功|/Admin/PermissionData/Index") : Content(ContentIcon.Error + "|操作失败");
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                PermissionDataLogic ml = new PermissionDataLogic();

                PermissionData obj = ml.GetPermissionData(id);

                return View(obj);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            try
            {
                PermissionDataLogic ml = new PermissionDataLogic();

                PermissionData obj = ml.GetPermissionData(id);

                UpdateModel(obj);

                obj.LastUpdateDate = DateTime.Now;

                obj.LastUpdateUserID = ID;

                bool result = ml.Update(obj);

                return result ? Content(ContentIcon.Succeed + "|操作成功") : Content(ContentIcon.Error + "|操作失败");
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                PermissionDataLogic ml = new PermissionDataLogic();
                if (id != null && id > 0)
                    ml.Delete(id ?? 0);
                else
                {
                    if (string.IsNullOrEmpty(collection["IDs"]))
                        return Content("未指定删除对象ID");
                    string[] ids = collection["IDs"].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in ids)
                    {
                        ml.Delete(int.Parse(item));
                    }
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ErrorWirter(RouteData, ex.Message));
            }
        }
        public ActionResult Detail(int id)
        {
            try
            {
                PermissionDataLogic ml = new PermissionDataLogic();

                PermissionData obj = ml.GetPermissionData(id);

                return View(obj);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }
        #region ajax 返回某人或某角色的权限
        public ActionResult GetPDatas(int type, int id)
        {
            string result = "";
            string sql = "";
            if (type == 0)
            {
                sql = "Select PID FROM [dbo].[PermissionData] WHERE [HasPermission]=1 AND [RID]=" + id;
            }
            else
            {
                sql = "Select PID  FROM [dbo].[PermissionData] WHERE[HasPermission]=1 AND [MID]=" + id;
            }
            var dt = dbHelper.ExecuteDataTableSql(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    try
                    {
                        result += item[0].ToString() + ",";
                    }
                    catch { }
                }
                if (!string.IsNullOrEmpty(result))
                {
                    result = result.Substring(0, result.Length - 1);
                }
            }
            return Content(result);
        }
        #endregion
    }
}


