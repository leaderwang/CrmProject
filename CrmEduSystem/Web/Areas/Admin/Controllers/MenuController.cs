using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using MvcPager;
using System.Text;
using System.Data;
using System.IO;
using Common;
using Lib;

namespace Web.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {

        public ActionResult Index(int? pageIndex, int? pageSize, Menu entity)
        {
            try
            {
                MenuLogic ml = new MenuLogic();

                IList<Menu> objs = ml.GetMenus(entity).ToPagedList(pageIndex ?? PageIndex, pageSize ?? PageSizeMax);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Index", objs);
                }
                else
                {
                    ViewData["TR"] = ForeachMenuByTr(0);
                    return View(objs);
                }
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        public ActionResult Create(int? ParentID)
        {
            ViewData["ForeachMenuByOption"] = ForeachMenuByOption(ParentID, 0);
            return View(new Menu());
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            try
            {
                MenuLogic ml = new MenuLogic();

                Menu obj = new Menu() { CreateDate = DateTime.Now, CreateUserID = ID, IsDeleted = false };

                UpdateModel(obj);
                int level = 1;
                if (obj.ParentID > 0)
                    level = (int)(ml.GetMenu(new Menu { ID = obj.ParentID ?? 0 }).Level + 1);
                obj.Level = level;

                bool result = ml.Add(obj);

                return result ? Content(ContentIcon.Succeed + "|保存成功|/admin/Menu/Index") : Content(ContentIcon.Error + "|保存失败");
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
                MenuLogic ml = new MenuLogic();

                Menu obj = ml.GetMenu(id);

                ViewData["ForeachMenuByOption"] = ForeachMenuByOption(obj.ParentID, 0);

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
                MenuLogic ml = new MenuLogic();

                Menu obj = ml.GetMenu(id);

                UpdateModel(obj);

                obj.LastUpdateDate = DateTime.Now;

                obj.LastUpdateUserID = ID;
                int level = 1;
                if (obj.ParentID > 0)
                    level = (int)(ml.GetMenu(new Menu { ID = obj.ParentID ?? 0 }).Level + 1);
                obj.Level = level;
                bool result = ml.Update(obj);

                return result ? Content(ContentIcon.Succeed + "|保存成功") : Content(ContentIcon.Error + "|保存失败");
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                MenuLogic ml = new MenuLogic();
                if (id > 0)
                    ml.Delete(id);
                else
                {
                    return Content("未指定删除对象ID");
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                MenuLogic ml = new MenuLogic();
                if (id != null && id > 0)
                    ml.Remove(id ?? 0);
                else
                {
                    if (string.IsNullOrEmpty(collection["IDs"]))
                        return Content("未指定删除对象ID");
                    string[] ids = collection["IDs"].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in ids)
                    {
                        ml.Remove(int.Parse(item));
                    }
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ErrorWirter(RouteData, ex.Message));
            }
        }

        #region 递归函数
        /// <summary>
        /// 返回下拉列表项Option项
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        private string ForeachMenuByOption(int? id, int? ParentID)
        {
            StringBuilder html = new StringBuilder();
            List<Menu> menulist = new MenuLogic().GetMenus(new Menu { ParentID = ParentID });
            var i = 0;
            foreach (var item in menulist)
            {
                string selected = "";
                if (id == item.ID)
                    selected = "selected";
                if (item.ParentID == 0 || item.ParentID.ToString() == "")
                    html.Append("<option value='" + item.ID + "' " + selected + "> " + item.Name + " </option>");
                else
                {
                    StringBuilder nbsp = new StringBuilder();
                    for (int j = 0; j < item.Level * 2; j++)
                    {
                        nbsp.Append("&nbsp;");
                    }
                    if (i == menulist.Count() - 1)
                    {
                        html.Append("<option value='" + item.ID + "' " + selected + "> " + nbsp.ToString() + "└ " + item.Name + " </option>");
                    }
                    else
                    {
                        html.Append("<option value='" + item.ID + "' " + selected + "> " + nbsp.ToString() + "├ " + item.Name + " </option>");
                    }
                }
                i++;
                html.Append(ForeachMenuByOption(id, item.ID));
            }
            return html.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string foreachMenu(int id)
        {
            string str = "";
            Menu menu = new MenuLogic().GetMenu(id);
            str += " > " + menu.Name;
            if (menu.ParentID != null)
            {
                str += foreachMenu((int)menu.ParentID);
            }
            return str;
        }

        /// <summary>
        /// 递归得到列表
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        private string ForeachMenuByTr(int? ParentID)
        {
            string tr = "<tr><td class='checkbox-column'><input type='checkbox' name='ID' value='{0}'/></td>" +
                        "<td>{0}</td>" +
                        "<td>{1}</td>" +
                        "<td>{2}</td>" +
                        @"<td>{3}</td>
                          <td class='btns-column'>
                              <a href='/admin/menu/Create?ParentID={0}' class='tip' title='添加子栏目'><i class='icol-chart-organisation'></i></a>
                              <a href='/admin/Menu/Edit?id={0}' class='tip' title='编辑'><i class='icon-pencil'></i></a>"
                              +"<a href='javascript:void(0);' onclick=\"Delete('/admin/Menu/Delete/{0}',this,'one');\"><i class='icon-trash tip' title='编辑'></i></a></td></tr>";
            StringBuilder html = new StringBuilder();
            List<Menu> menulist = new MenuLogic().GetMenus(new Menu { ParentID = ParentID }, string.Empty, "Sort", "Asc");
            var i = 0;
            foreach (var item in menulist)
            {
                StringBuilder name = new StringBuilder();
                if (item.ParentID == 0 || item.ParentID.ToString() == "")
                    name.Append(item.Name);
                else
                {
                    string nbsp = "<em style='display:inline-block;padding:0 " + 4 * item.Level + "px'></em>"; ;
                    if (i == menulist.Count() - 1)
                    {
                        name.Append(nbsp + "└─ " + item.Name);
                    }
                    else
                    {
                        name.Append(nbsp + "├─ " + item.Name);
                    }
                }
                html.Append(string.Format(tr,
                    item.ID,
                    item.Sort,
                    name.ToString(), item.Url));
                html.Append(ForeachMenuByTr(item.ID));
                i++;
            }
            return html.ToString();
        }
        #endregion
    }
}


