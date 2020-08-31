using AsmFinal.Models;
using AsmFinal.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsmFinal.Controllers
{
    [Authorize(Roles = "Staff,Trainer")]
    public class TrainersController : Controller
    {
        
        // GET: Trainers
        private ApplicationDbContext _context;
        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var usersWithRoles = (from user in _context.Users
                                  select new
                                  {
                                      Username = user.UserName,
                                      user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in _context.Roles on userRole.RoleId equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UserViewModel()

                                  {
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });
            return View(usersWithRoles);
        }
        [HttpGet]
        public ActionResult Assign()
        {

            var viewModel = new TrainerTopicViewModel();
            viewModel.Topics = _context.Topics.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Assign(ApplicationUser trainer)
        {
            
            _context.Users.Add(trainer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}