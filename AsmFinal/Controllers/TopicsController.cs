using AsmFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AsmFinal.ViewModel;
using Microsoft.AspNet.Identity;

namespace AsmFinal.Controllers
{
    [Authorize(Roles = "Staff,Trainer")]
    public class TopicsController : Controller
    {
        private ApplicationDbContext _context;
        public TopicsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            var list = _context.Topics.Include(p => p.Course).ToList();
            
            
            return View(list);

        }
        [HttpGet]
        public ActionResult Create()
        {

            var viewModel = new TopicCourseViewModel();
            viewModel.Courses = _context.Courses.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            _context.Topics.Add(topic);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int id)
        {
            var productInDb = _context.Topics.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
            {
                return HttpNotFound();
            }

            _context.Topics.Remove(productInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var CourseInDb = _context.Topics.SingleOrDefault(m => m.Id == id);
            if (CourseInDb == null) return HttpNotFound();

            var viewModel = new TopicCourseViewModel()
            {
                Courses = _context.Courses.ToList(),
                Topic = CourseInDb
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            var CourseInDb = _context.Topics.SingleOrDefault(m => m.Id == topic.Id);
            CourseInDb.Name = topic.Name;
            CourseInDb.Detail = topic.Detail;
            CourseInDb.CourseId = topic.CourseId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}