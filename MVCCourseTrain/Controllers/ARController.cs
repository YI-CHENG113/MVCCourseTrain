using Microsoft.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourseTrain.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult VR1()
        {
            return View();
        }
        public ActionResult VR2()
        {
            return View();
        }
        public ActionResult VR3()
        {
            return View("VR2");
        }
        public ActionResult VR4()
        {
            return View("VR2", "_Layout2");
        }
        public ActionResult PVR1()
        {
            return PartialView("VR2");
        }

        public ActionResult Robots()
        {
            return PartialView();
        }
        public ActionResult FRView()
        {
            return View();
        }

        public ActionResult FR1(bool isDownload = false)
        {
            return File(Server.MapPath("~/Content/NBAGAMEFINAL.jpg"), "image/jpeg");
        }

        public ActionResult FR2()
        {
            return File(Server.MapPath(
                "~/Content/NBAGAMEFINAL.jpg"),
                "image/jpeg",
                "NBAGAMEFINAL(4).jpg");
        }
        public ActionResult JsonR()
        {
            return Json(new
            {
                Name = "Will"
            }, JsonRequestBehavior.AllowGet);
        }
        [ContentType("text/xml")]
        public ActionResult GetXML()
        {
            return PartialView();
        }
    }
}