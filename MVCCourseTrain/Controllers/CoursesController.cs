using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCourseTrain.Models;
using Omu.ValueInjecter;
using MVCCourseTrain.ViewModels;

namespace MVCCourseTrain.Controllers
{
    public class CoursesController : BaseController
    {
        //private ContosoUniversityEntities db = new ContosoUniversityEntities();
        CourseRepository repo = RepositoryHelper.GetCourseRepository();
        DepartmentRepository repoDept;
        public CoursesController()
        {
            repoDept = RepositoryHelper.GetDepartmentRepository(repo.UnitOfWork);
        }

        // GET: Courses
        public ActionResult Index(CourseFilter filter)
        {
            //var course = repo.All();
            //return View(course.ToList());
            if (!ModelState.IsValid)
            {

                return View(new List<Course>());
            }
            ViewData.Model = repo.Search(filter);
            return View();
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Course course = repo.All().FirstOrDefault(p => p.CourseID == id);
            Course course = repo.FindOne(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(repoDept.All(), "DepartmentID", "Name");
            return View();
        }

        // POST: Courses/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID,IsDelete")] Course course)
        {
            if (ModelState.IsValid)
            {
                //db.Course.Add(course);
                //db.SaveChanges();
                repo.Add(course);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(repoDept.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Course course = repo.All().FirstOrDefault(p => p.CourseID == id);
            Course course = repo.FindOne(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(repoDept.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID,IsDelete")] Course course)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(course).State = EntityState.Modified;
                //db.SaveChanges();
                //Course c = repo.All().FirstOrDefault(p => p.CourseID == course.CourseID);
                Course c = repo.FindOne(course.CourseID);
                c.InjectFrom(course);
                repo.UnitOfWork.Commit();
                TempData["Message"] = "更新 " + c.Title + " 成功!";
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(repoDept.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Course course = repo.All().FirstOrDefault(p => p.CourseID == id);
            Course course = repo.FindOne(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Course course = db.Course.Find(id);
            //db.Course.Remove(course);
            //db.SaveChanges();
           // Course course = repo.All().FirstOrDefault(p => p.CourseID == id);
           // course.IsDelete = true;
            Course course = repo.FindOne(id);
            repo.Delete(course);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
