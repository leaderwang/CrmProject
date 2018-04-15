using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using MvcPager;
using DbUtility;
using Lib;

namespace Web.Areas.Admin.Controllers
{
	/// <summary>
    /// Course 控制器
    /// </summary>
    public class CourseController : BaseController
    {

        public ActionResult Index(int? pageIndex, int? pageSize, Course entity)
        {
            try
            {
                CourseLogic ml = new CourseLogic();
				entity.IsDeleted = false;
				PagedList<Course> page = ml.GetCourses(entity, pageIndex ?? PageIndex, pageSize ?? PageSize, Order,By);
                if (Request.IsAjaxRequest())
                    return PartialView("_Index",  page);
                return View(page);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|"+ErrorWirter(RouteData, ex.Message));
            }
        }

        public ActionResult Create()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            try
            {
                CourseLogic ml = new CourseLogic();

                Course obj = new Course() { CompanyID = CompanyID, CreateDate = DateTime.Now, CreateUserID = ID,  IsDeleted = false };

                UpdateModel(obj);

                bool result = ml.Add(obj);

                return result ? Content(ContentIcon.Succeed + "|操作成功|/Admin/Course/Index") : Content(ContentIcon.Error + "|操作失败");
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|"+ErrorWirter(RouteData, ex.Message));
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                CourseLogic ml = new CourseLogic();

                Course obj = ml.GetCourse(id);

                return View(obj);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|"+ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            try
            {
                CourseLogic ml = new CourseLogic();

				Course obj = ml.GetCourse(id);

				UpdateModel(obj);

                obj.LastUpdateDate = DateTime.Now;

                obj.LastUpdateUserID = ID;

                bool result = ml.Update(obj);

                return result ? Content(ContentIcon.Succeed + "|操作成功") : Content(ContentIcon.Error + "|操作失败");
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|"+ErrorWirter(RouteData, ex.Message));
            }
        }

        [HttpPost]
        public ActionResult Delete(int? id,FormCollection collection)
        {
            try
            {
                CourseLogic ml = new CourseLogic();
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
                CourseLogic ml = new CourseLogic();

                Course obj = ml.GetCourse(id);

                return View(obj);
            }
            catch (Exception ex)
            {
                return Content(ContentIcon.Error + "|" + ErrorWirter(RouteData, ex.Message));
            }
        }
    }
}


