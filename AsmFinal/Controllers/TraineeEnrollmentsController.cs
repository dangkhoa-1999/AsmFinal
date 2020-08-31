using AsmFinal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AsmFinal.ViewModel;

namespace AsmFinal.Controllers
{
    
    public class TraineeEnrollmentsController : Controller
    {
        private ApplicationDbContext _context;
        public TraineeEnrollmentsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Role
        public ActionResult Index()
        {


            if (User.IsInRole("Staff"))
            {
                var traineecourses = _context.TraineeEnrollments.Include(t => t.Enrollment).Include(t => t.Trainee).ToList();
                return View(traineecourses);
            }
            if (User.IsInRole("Trainee"))
            {
                var traineeId = User.Identity.GetUserId();
                var Res = _context.TraineeEnrollments.Where(e => e.TraineeId == traineeId).Include(t => t.Enrollment).ToList();
                return View(Res);
            }
            return View("Index");
        }

        public ActionResult Create()
        {
            //get trainer
            var role = (from r in _context.Roles where r.Name.Contains("Trainee") select r).FirstOrDefault();
            var users = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

            //get topic

            var courses = _context.Enrollments.ToList();

            var TrainerTopicVM = new TraineeEnrollmentViewModel()
            {
                Enrollments = courses,
                Trainees = users,
                TraineeEnrollment = new TraineeEnrollment()
            };

            return View(TrainerTopicVM);
        }

        [HttpPost]
        public ActionResult Create(TraineeEnrollmentViewModel model)
        {
            //get trainer
            var role = (from r in _context.Roles where r.Name.Contains("Trainee") select r).FirstOrDefault();
            var users = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

            //get topic

            var courses = _context.Enrollments.ToList();


            if (ModelState.IsValid)
            {
                _context.TraineeEnrollments.Add(model.TraineeEnrollment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var TrainerTopicVM = new TraineeEnrollmentViewModel()
            {
                Enrollments = courses,
                Trainees = users,
                TraineeEnrollment = new TraineeEnrollment()
            };

            return View(TrainerTopicVM);
        }
    }
}


