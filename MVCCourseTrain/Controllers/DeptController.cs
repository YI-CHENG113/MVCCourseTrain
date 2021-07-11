using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCourseTrain.Models;
using MVCCourseTrain.ViewModels;
using System.Diagnostics;
using Omu.ValueInjecter;
using System;



namespace MVCCourseTrain.Controllers
{
    public class DeptController : Controller
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();
        public DeptController()
        {
            db.Database.Log = (msg) => Debug.WriteLine(msg);
        }
        // GET: Dept
        public ActionResult Index()
        {
            return View(db.Department.Include(d => d.Manager));
        }
        public ActionResult Details(int id)
        {
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentCreate department)
        {
            if (ModelState.IsValid)
            {
                var dept = new Department();
                dept.InjectFrom(department);
                dept.StartDate = DateTime.Now;

                db.Department.Add(dept);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        public ActionResult Edit(int id)
        {
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(new DepartmentEdit().InjectFrom(department));
        }

        [HttpPost]
        public ActionResult Edit(int id, DepartmentEdit department)
        {
            if (ModelState.IsValid)
            {
                Department dept = db.Department.Find(id);
                dept.InjectFrom(department);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        public ActionResult Delete(int id)
        {
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Department dept = db.Department.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            db.Department.Remove(dept);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}