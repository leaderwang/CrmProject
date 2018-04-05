﻿using System.Web.Mvc;

namespace eDoctorBaseFrame.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            ViewData["error"] = System.Web.HttpContext.Current.Application["error"];
            System.Web.HttpContext.Current.Application["error"] = "";
            return View();
        }
    }
}