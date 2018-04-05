using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using MvcPager;
using DbUtility;
using System.Text;
using Lib;

namespace Web.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {

        public ActionResult Index(int? pageIndex, int? pageSize, Role entity)
        {
            try
            {
                RoleLogic ml = new RoleLogic();

                PagedList<Role> page = ml.GetRoles(entity, pageIndex ?? PageIndex, pageSize ?? PageSize, Order, By);

                IList<Role> objs = page;

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
            return View(new Role());
        }

        [HttpPost]
        public ActionResult Create(int[] kids, FormCollection formCollection)
        {
            try
            {
                RoleLogic ml = new RoleLogic();

                Role obj = new Role() { CreateDate = DateTime.Now, CreateUserID = ID, IsDeleted = false };

                UpdateModel(obj);

                int rid = ml.Create(obj);

                #region 更新引角色权限
                if (rid > 1)
                {
                    var pdl = new PermissionDataLogic();
                    pdl.DeleteByMIDOrRID(rid, 0);
                    var pmlts = new PermissionMapLogic().GetPermissionMaps();
                    if (pmlts != null)
                    {
                        string pData = formCollection["pData"];
                        foreach (var item in pmlts)
                        {
                            var pdt = new PermissionData()
                            {
                                PID = item.ID,
                                RID = rid,
                                HasPermission = false,
                                CreateUserID = Lib.CurrentMember.ID,
                                LastUpdateUserID = Lib.CurrentMember.ID,
                                CreateDate = DateTime.Now,
                                LastUpdateDate = DateTime.Now,
                                IsDeleted = false
                            };
                            if (!string.IsNullOrEmpty(pData))
                            {
                                try
                                {
                                    var pDataArr = pData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (pDataArr.Contains(item.ID.ToString()))
                                    {
                                        pdt.HasPermission = true;
                                    }
                                }
                                catch { }
                            }
                            pdl.Add(pdt);
                        }
                    }
                }
                Lib.PermissionHelper permission = new Lib.PermissionHelper();
                permission.Write();
                #endregion

                return Content(ContentIcon.Succeed + "|保存成功|/admin/Role/Index");
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
                RoleLogic ml = new RoleLogic();

                Role obj = ml.GetRole(id);

                return View(obj);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, int[] kids, FormCollection formCollection)
        {
            try
            {
                RoleLogic ml = new RoleLogic();

                Role obj = ml.GetRole(id);

                UpdateModel(obj);

                obj.LastUpdateDate = DateTime.Now;

                obj.LastUpdateUserID = ID;

                bool result = ml.Update(obj);

                int rid = obj.ID;

                #region 更新引角色权限
                if (rid > 1)
                {
                    var pdl = new PermissionDataLogic();
                    pdl.DeleteByMIDOrRID(rid, 0);
                    var pmlts = new PermissionMapLogic().GetPermissionMaps();
                    if (pmlts != null)
                    {
                        string pData = formCollection["pData"];
                        foreach (var item in pmlts)
                        {
                            var pdt = new PermissionData()
                            {
                                PID = item.ID,
                                RID = rid,
                                HasPermission = false,
                                CreateUserID = Lib.CurrentMember.ID,
                                LastUpdateUserID = Lib.CurrentMember.ID,
                                CreateDate = DateTime.Now,
                                LastUpdateDate = DateTime.Now,
                                IsDeleted = false
                            };
                            if (!string.IsNullOrEmpty(pData))
                            {
                                try
                                {
                                    var pDataArr = pData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (pDataArr.Contains(item.ID.ToString()))
                                    {
                                        pdt.HasPermission = true;
                                    }
                                }
                                catch { }
                            }
                            pdl.Add(pdt);
                        }
                    }
                }
                Lib.PermissionHelper permission = new Lib.PermissionHelper();
                permission.Write();
                #endregion

                return result ? Content(ContentIcon.Succeed + "|保存成功") : Content(ContentIcon.Error + "|保存失败");
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            RoleLogic ml = new RoleLogic();
            try
            {
                if (id > 0)
                {
                    var mlts = new MemberLogic().GetMembers(new Member() { IsDeleted = false, RoleID = id });
                    if (mlts != null && mlts.Count > 0)
                    {
                        return Content(ContentIcon.Error + "|当前角色下含有用户，请先将用户删除");
                    }
                    else
                    {
                        ml.Delete(id);
                        return Content("1");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(collection["IDs"]))
                        return Content("未指定删除对象ID");
                    string[] ids = collection["IDs"].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in ids)
                    {
                        ml.Delete(int.Parse(item));
                    }
                    return Content("1");
                }
            }
            catch (Exception ex)
            {
                return Content(ErrorWirter(RouteData, ex.Message));
            }
        }

    }
}


