using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Common;
using Models;
using MvcPager;
using DbUtility;
using Lib;

namespace Web.Areas.Admin.Controllers
{
    public class MemberController : BaseController
    {

        public ActionResult Index(int? pageIndex, int? pageSize, View_Member entity)
        {
            try
            {
                View_MemberLogic ml = new View_MemberLogic();

                PagedList<View_Member> page = ml.GetView_Members(entity, pageIndex ?? PageIndex, pageSize ?? PageSize, Order, By);

                if (Request.IsAjaxRequest())

                    return PartialView("_Index", page);

                return View(page);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        public ActionResult Create()
        {
            return View(new Member() { UserNo= Character.GetUniqueCodeString("U") });
        }

        [HttpPost]
        public ActionResult Create(int[] kids, FormCollection formCollection)
        {
            try
            {
                MemberLogic ml = new MemberLogic();

                Member obj = new Member() { CompanyID = CompanyID, CreateDate = DateTime.Now, CreateUserID = ID, IsDeleted = false };

                UpdateModel(obj);
                obj.Password = Common.Character.EncrytPassword(obj.PwdNotMD5);
                bool result = false;
                int mid = ml.Create(obj);

                #region 更新引用户权限
                //if (mid > 2)
                //{
                //    var pdl = new PermissionDataLogic();
                //    pdl.DeleteByMIDOrRID(mid, 1);
                //    var pmlts = new PermissionMapLogic().GetPermissionMaps();
                //    if (pmlts != null)
                //    {
                //        string pData = formCollection["pData"];
                //        foreach (var item in pmlts)
                //        {
                //            var pdt = new PermissionData()
                //            {
                //                PID = item.ID,
                //                MID = mid,
                //                HasPermission = false,
                //                CreateUserID = Lib.CurrentMember.ID,
                //                LastUpdateUserID = Lib.CurrentMember.ID,
                //                CreateDate = DateTime.Now,
                //                LastUpdateDate = DateTime.Now,
                //                IsDeleted = false
                //            };
                //            if (!string.IsNullOrEmpty(pData))
                //            {
                //                try
                //                {
                //                    var pDataArr = pData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //                    if (pDataArr.Contains(item.ID.ToString()))
                //                    {
                //                        pdt.HasPermission = true;
                //                    }
                //                }
                //                catch { }
                //            }
                //            pdl.Add(pdt);
                //        }
                //    }
                //}
                #endregion

                result = true;
                return result ? Content(ContentIcon.Succeed + "|保存成功|/admin/Member/Index") : Content(ContentIcon.Error + "|保存失败");
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
                MemberLogic ml = new MemberLogic();

                Member obj = ml.GetMember(id);

                return View(obj);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult Edit(int[] kids, int id, FormCollection formCollection)
        {
            try
            {
                MemberLogic ml = new MemberLogic();

                Member obj = ml.GetMember(id);

                UpdateModel(obj);

                obj.LastUpdateDate = DateTime.Now;

                obj.LastUpdateUserID = ID;

                obj.Password = Common.Character.EncrytPassword(obj.PwdNotMD5);

                bool result = ml.Update(obj);

                int mid = obj.ID;

                #region 更新引用户权限
                //if (mid > 2)
                //{
                //    var pdl = new PermissionDataLogic();
                //    pdl.DeleteByMIDOrRID(mid, 1);
                //    var pmlts = new PermissionMapLogic().GetPermissionMaps();
                //    if (pmlts != null)
                //    {
                //        string pData = formCollection["pData"];
                //        foreach (var item in pmlts)
                //        {
                //            var pdt = new PermissionData()
                //            {
                //                PID = item.ID,
                //                MID = mid,
                //                HasPermission = false,
                //                CreateUserID = Lib.CurrentMember.ID,
                //                LastUpdateUserID = Lib.CurrentMember.ID,
                //                CreateDate = DateTime.Now,
                //                LastUpdateDate = DateTime.Now,
                //                IsDeleted = false
                //            };
                //            if (!string.IsNullOrEmpty(pData))
                //            {
                //                try
                //                {
                //                    var pDataArr = pData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //                    if (pDataArr.Contains(item.ID.ToString()))
                //                    {
                //                        pdt.HasPermission = true;
                //                    }
                //                }
                //                catch { }
                //            }
                //            pdl.Add(pdt);
                //        }
                //    }
                //}
                #endregion

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
                MemberLogic ml = new MemberLogic();
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
                MemberLogic ml = new MemberLogic();
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


        public ActionResult Export()
        {
            try
            {

                DBContext db = new DBContext();
                var sqlStr = @" selecT ID,RealName,Mobile,Address,OpenID,Province,City,Country,Hospital,Department,CreateDate from dbo.Member    order by createdate  ";
                StringBuilder where = new StringBuilder(sqlStr);
                //if (!string.IsNullOrWhiteSpace(basicid))
                //{
                //    where.Append(" and basicid ='" + basicid + "'");
                //}
                //if (!string.IsNullOrWhiteSpace(area))
                //{
                //    where.Append(" and area ='" + area + "'");
                //}
                //if (!string.IsNullOrWhiteSpace(province))
                //{
                //    where.Append(" and Province ='" + province + "'");
                //}
                //if (!string.IsNullOrWhiteSpace(city))
                //{
                //    where.Append(" and City ='" + city + "'");
                //}
                //if (begin.HasValue)
                //{
                //    where.Append(string.Format(" and a.CreateDate>='{0}'", begin.Value.ToString("yyyy-MM-dd")));
                //}
                //if (end.HasValue)
                //{
                //    where.Append(string.Format(" and a.CreateDate<'{0}'", end.Value.AddDays(1).ToString("yyyy-MM-dd")));
                //}
                //where.Append(" order by a.CreateDate desc");
                var dt = db.ExecuteDataTableSql(where.ToString());
                // Common.ExcelHelper.GetExcel(dt, DateTime.Now.ToString("yyyyMMddHHmmss"));

                OpenXmlExcelHelper.ExportByWeb(dt, DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx", "sheet1");
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
        /// 导出知识挑战中每期的得分及用户名单
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportQuestion(int? qid, int? tid)
        {
            try
            {
                DBContext db = new DBContext();
                var strWhere = string.Empty;
                //if (qid > 0)
                //{
                //    strWhere += string.Format("AND temp.Quarter={0}", qid);
                //}

                //if (tid > 0)
                //{
                //    strWhere += string.Format("AND temp.tid={0}", tid);
                //}
                //忽略
                var strSql = string.Format(@"
                                         SELECT 
                                                temp.tid, 
                                                 CASE WHEN temp.Quarter = 1 THEN '第一季度'
                                                     WHEN temp.Quarter = 2 THEN '第二季度'
                                                     WHEN temp.Quarter = 3 THEN '第三季度'
                                                     ELSE '第四季度'
                                                END AS Quarter ,
                                                temp.openid ,
                                                temp.RealName ,
                                                COUNT(temp.qid) OVER ( PARTITION BY temp.openid ) total ,
                                                temp.BrandId,
                                                CONVERT(VARCHAR, temp.CreateDate, 111) CreateDate
                                        FROM    ( SELECT d.tid,datepart(quarter,d.createdate) Quarter,ROW_NUMBER() OVER ( PARTITION BY d.userid, d.qid ORDER BY d.id ) Num ,
                                                            d.qid ,
                                                            d.openid ,
                                                            m.realName ,
                                                            1000 + d.qid AS BrandId ,
                                                            CONVERT(VARCHAR, d.CreateDate, 111) CreateDate
                                                    FROM      dbo.DB_QList d
                                                            INNER JOIN dbo.member m ON d.openid = m.OpenID
                                                    WHERE     d.useranswer = CAST(d.answer AS NVARCHAR(200))
                                                ) temp
                                        WHERE   temp.Num = 1 {0}
                                        ORDER BY temp.openid DESC ,
                                                CreateDate ASC  ", strWhere);

                var sql_export = "selecT RealName 姓名,total 得分,BrandID 期号,CreateDate 提交时间 from   dbo.View_ExamList  order by BrandID desc";


                StringBuilder where = new StringBuilder(strSql);

                var dt = db.ExecuteDataTableSql(sql_export);

                if (dt.Rows.Count > 0)
                {
                    OpenXmlExcelHelper.ExportByWeb(dt, DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx", "sheet1");
                }
                else
                {
                    Response.Clear();
                    // Response.Write("没有数据可供导出");
                    Response.Write("<script>alert(\"没有数据可供导出\"); history.back();</script>");
                    Response.Flush();
                    Response.End();
                }
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


