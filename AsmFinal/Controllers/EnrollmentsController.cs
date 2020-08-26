using AsmFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AsmFinal.ViewModel;

namespace AsmFinal.Controllers
{
    public class EnrollmentsController : Controller
    {
        private ApplicationDbContext _context;
        public EnrollmentsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            var list = _context.Enrollments.Include(p => p.Course).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {

            var viewModel = new EnrollmentCourseViewModel();
            viewModel.Courses = _context.Courses.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int id)
        {
            var productInDb = _context.Enrollments.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
            {
                return HttpNotFound();
            }

            _context.Enrollments.Remove(productInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var CourseInDb = _context.Enrollments.SingleOrDefault(m => m.Id == id);
            if (CourseInDb == null) return HttpNotFound();

            var viewModel = new EnrollmentCourseViewModel()
            {
                Courses = _context.Courses.ToList(),
                Enrollment = CourseInDb
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(Enrollment enrollment)
        {
            var CourseInDb = _context.Enrollments.SingleOrDefault(m => m.Id == enrollment.Id);
            CourseInDb.EnrollmentDateExpired = enrollment.EnrollmentDateExpired;
            CourseInDb.EnrollmentDateStarted = enrollment.EnrollmentDateStarted;
            CourseInDb.CourseId = enrollment.CourseId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}