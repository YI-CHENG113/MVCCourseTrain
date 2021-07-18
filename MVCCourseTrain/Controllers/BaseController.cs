using MVCCourseTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseTrain.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ContosoUniversityEntities db = new ContosoUniversityEntities();
        protected override void HandleUnknownAction(string actionName)
        {
            //base.HandleUnknownAction(actionName);
            this.RedirectToAction("Index", new { actionName }).ExecuteResult(this.ControllerContext);
        }
        // GET: Base
        public ActionResult Debug123()
        {
            return View();
        }
    }
}