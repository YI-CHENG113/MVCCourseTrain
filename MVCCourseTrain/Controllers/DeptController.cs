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
using MVCCourseTrain.ActionFilters;
using System.Data.Entity.Validation;

namespace MVCCourseTrain.Controllers
{
    public class DeptController : BaseController
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();
        DepartmentRepository repo = RepositoryHelper.GetDepartmentRepository();
        public DeptController()
        {
            db.Database.Log = (msg) => Debug.WriteLine(msg);
        }
        // GET: Dept
        public ActionResult Index()
        {
            return View(db.Department.Include(d => d.Manager));
        }
        public ActionResult BatchEdit()
        {
            return View(db.Department.Include(d => d.Manager));
        }

        [HttpPost]
        [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "ErrorDbEntityValidationException")]

        public ActionResult BatchEdit(BatchEditViewModel[] data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var one = repo.FindOne(item.DepartmentID);
                    one.InjectFrom(item);
                }


                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

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

        [產生ViewBag點InstructorID並設定SelectList給View]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [產生ViewBag點InstructorID並設定SelectList給View]
        [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "ErrorDbEntityValidationException")]
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
        [產生ViewBag點InstructorID並設定SelectList給View]
        public ActionResult Edit(int id)
        {
            var department = (from p in db.Department
                              where p.DepartmentID == id
                              select new DepartmentEdit()
                              {
                                  Budget = p.Budget,
                                  Name = p.Name,
                                  InstructorID = p.InstructorID,
                                  StartDate = p.StartDate
                              }).FirstOrDefault();
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost]
        [產生ViewBag點InstructorID並設定SelectList給View]
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