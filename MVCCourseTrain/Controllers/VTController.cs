using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseTrain.Controllers
{
    public class VTController : Controller
    {
        // GET: VT
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Page1()
        {
            return View();
        }
    }
}