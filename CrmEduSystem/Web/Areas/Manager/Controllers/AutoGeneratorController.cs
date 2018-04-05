﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using System.Data;
using Web.Areas.Manager.Helper;
using System.IO;
using DbUtility;

namespace Web.Areas.Manager.Controllers
{
    public class AutoGeneratorController : BaseController
    {
        //
        // GET: /Manager/AutoGenerator/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取数据库表列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDBTables()
        {
            string result = "";
            DbUtility.DBContext dbhelper = new DbUtility.DBContext(PathHelper.DBConnectionString);
            DataTable dt = new DataTable();
            dt = dbhelper.ExecuteDataTableSql("select name from SYSOBJECTS where xtype='U' or  xtype='V' order by Name;");
            foreach (DataRow item in dt.Rows)
            {
                result += "<div>" + item[0] + "</div>";
            }
            return Content(result);
        }
        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTempPathList()
        {
            string result = "";
            var dirs = Directory.GetDirectories(Web.Areas.Manager.Helper.PathHelper.Templepath);
            foreach (var item in dirs)
            {
                var str = (item.Substring(item.LastIndexOf("\\") + 1));
                result += "<option value=\"" + str + "\">" + str + "</option>";
            }
            return Content(result);
        }


        #region 菜单操作
        List<Models.Menu> mlts = new List<Models.Menu>();
        List<string> menuItems = new List<string>();
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMenuList()
        {
            string result = "";
            var dbhelper = new DbUtility.DBContext(PathHelper.DBConnectionString);
            mlts = dbhelper.QueryForListSql<Models.Menu>("SELECT * FROM [dbo].[Menu] AS m");
            menuItems.Add("<option value=\"-1\">不加入到菜单</option>");
            menuItems.Add("<option value=\"0\">作为顶级菜单</option>");
            menuItems.AddRange(MenuList(0));
            foreach (var item in menuItems)
            {
                result += item;
            }
            return Content(result);
        }
        /// <summary>
        /// 菜单下拉列表递归
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        protected List<string> MenuList(int parentID)
        {
            List<string> result = new List<string>();
            if (mlts != null)
            {
                var tlts = mlts.Where(b => b.ParentID == parentID).OrderBy(b => b.Sort).ToList();
                if (tlts != null)
                {
                    foreach (var item in tlts)
                    {
                        string space = "";
                        for (int i = 1; i < item.Level + 1; i++)
                        {
                            space += "&nbsp;";
                        }
                        if (item == tlts.Last())
                        {
                            space += "&nbsp;└ ";
                        }
                        else
                        {
                            space += "&nbsp;├ ";
                        }
                        var str = "<option value=\"" + item.ID + "\">" + space + item.Name + "</option>";
                        result.Add(str);
                        var childs = MenuList(item.ID);
                        if (childs != null && childs.Count > 0) result.AddRange(childs);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 将当前模块添加到菜单
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        protected int InsertMenu(int parentID, string Name)
        {
            DBContext db = new DBContext(PathHelper.DBConnectionString);
            int id = 0;
            int level = 1;
            if (parentID > 0)
            {
                try
                {
                    level = db.QueryForObjectSql<Models.Menu>("SELECT * FROM [dbo].[Menu] AS m WHERE [ID]=" + parentID).Level ?? 1;
                    level++;
                }
                catch
                {
                    level = 1;
                }
            }
            Models.Menu mt1 = new Models.Menu()
            {
                Name = Name,
                ParentID = parentID,
                Icon = "icol-buildings",
                Url = "/Admin/" + Name + "/Index",
                Sort = 0,
                Level = level,
                IsDeleted = false,
                LastUpdateUserID = 2,
                LastUpdateDate = DateTime.Now,
                CreateDate = DateTime.Now,
                CreateUserID = 2
            };
            try
            {
                var exitsMenu = db.QueryForListSql<Models.Menu>("SELECT Top 1 * FROM [dbo].[Menu] AS m WHERE [Name]='" + mt1.Name + "' AND [ParentID]=" + mt1.ParentID + " AND [Url]='" + mt1.Url + "'");
                if (exitsMenu == null || exitsMenu.Count < 1)
                {
                    try
                    {
                        if (level == 1)
                        {
                            Models.Menu mt0 = new Models.Menu()
                            {
                                Name = Name,
                                ParentID = parentID,
                                Icon = "icos-list-images",
                                Url = "",
                                Sort = 0,
                                Level = level,
                                IsDeleted = false,
                                LastUpdateUserID = 2,
                                LastUpdateDate = DateTime.Now,
                                CreateDate = DateTime.Now,
                                CreateUserID = 2
                            };
                            db.ExecuteNonQuerySql(db.ObjectToInsertSql<Models.Menu>(mt0));
                            id = Convert.ToInt32(db.ExecuteScalarSql("SELECT MAX([ID]) FROM [dbo].[Menu] AS m"));
                            mt1.ParentID = id;
                            mt1.Level = 2;
                        }
                    }
                    catch { }
                    db.ExecuteNonQuerySql(db.ObjectToInsertSql<Models.Menu>(mt1));
                }
            }
            catch { }
            try
            {
                id = Convert.ToInt32(db.ExecuteScalarSql("SELECT MAX([ID]) FROM [dbo].[Menu] AS m"));
            }
            catch { }
            return id;
        }
        #endregion


        #region 生成
        /// <summary>
        /// 生成操作
        /// </summary>
        /// <param name="tableStr">数据库</param>
        /// <param name="tempPath">模板地址</param>
        /// <param name="menuOption">菜单选项</param>
        /// <param name="generateObj">生成对象</param>
        /// <param name="isCover">是否覆盖</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Generate(string tableStr, string tempPath, int menuOption, string generateObj, bool isCover)
        {
            string result = "";
            GeneratorHelper generatorHelper = new GeneratorHelper(PathHelper.DBConnectionString, isCover);
            try
            {
                int check = 0;
                var tableArr = tableStr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                Web.Areas.Manager.Helper.PathHelper.SelectedTempPath = Web.Areas.Manager.Helper.PathHelper.Templepath + tempPath + "\\";
                if (tableArr.Length > 0 && !string.IsNullOrEmpty(Web.Areas.Manager.Helper.PathHelper.SelectedTempPath))
                {
                    foreach (var item in tableArr)
                    {
                        //生成实体相关
                        if (generateObj.IndexOf("实体") > -1)
                        {
                            generatorHelper.CreateFileFromTemplate(item.ToString(), "Entity");
                            generatorHelper.CreateFileFromTemplate(item.ToString(), "Logic");
                            generatorHelper.CreateFileFromTemplate(item.ToString(), "Service");
                            check += 3;
                        }
                        //生成Controller
                        if (generateObj.IndexOf("控制器") > -1)
                        {
                            generatorHelper.CreateFileFromTemplate(item.ToString(), "Controller");
                            check += 1;
                        }
                        //生成页面
                        if (generateObj.IndexOf("视图") > -1)
                        {
                            //生成菜单，将当前模块添加到指定菜单中
                            try
                            {
                                if (menuOption > -1)
                                {
                                    InsertMenu(menuOption, item.ToString());
                                }
                            }
                            catch { }
                            //创建页面
                            generatorHelper.CreateFileFromTemplate(item.ToString(), "Index");
                            generatorHelper.CreateFileFromTemplate(item.ToString(), "Create");
                            generatorHelper.CreateFileFromTemplate(item.ToString(), "Edit");
                            generatorHelper.CreateFileFromTemplate(item.ToString(), "_Form");
                            generatorHelper.CreateFileFromTemplate(item.ToString(), "Detail");
                            check += 7;
                        }

                    }
                }
                else
                {
                    result = "请选择要生成的对象或模板";
                }
                if (check == 0)
                    result = "请选择模板";
                else
                    result = "任务已完成！";
            }
            catch (Exception ex)
            {
                result = "生成模板的时候出现错误，错误信息为：" + ex.Message;
            }
            return Content(result);
        }
        #endregion

    }
}