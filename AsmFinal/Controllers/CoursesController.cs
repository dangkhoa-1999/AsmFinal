using AsmFinal.Models;
using AsmFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AsmFinal.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            var list = _context.Courses.Include(p=>p.Category).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {

            var viewModel = new CourseCategoryViewModel();
            viewModel.Categories = _context.Categories.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int id)
        {
            var productInDb = _context.Courses.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
            {
                return HttpNotFound();
            }

            _context.Courses.Remove(productInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var CourseInDb = _context.Courses.SingleOrDefault(m => m.Id == id);
            if (CourseInDb == null) return HttpNotFound();

            var viewModel = new CourseCategoryViewModel()
            {
                Categories = _context.Categories.ToList(),
                Course = CourseInDb
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(Course course)
        {
            var CourseInDb = _context.Courses.SingleOrDefault(m => m.Id == course.Id);
            CourseInDb.Name = course.Name;
            CourseInDb.Detail = course.Detail;
            CourseInDb.CategoryId = course.CategoryId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}