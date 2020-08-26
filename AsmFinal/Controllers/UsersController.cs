using AsmFinal.Models;
using AsmFinal.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Assignment.Controllers
{
    public class UsersController : Controller
    {


        private ApplicationDbContext _context;

        

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Users

        // GET: Users
        public ActionResult Index()
        {
          var usersWithRoles = (from user in _context.Users
                                  select new
                                  {
                                      Username = user.UserName,
                                      Email = user.Email,
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

        public ActionResult Delete(string id)
        {
            var productInDb = _context.Users.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
            {
                return HttpNotFound();
            }

            _context.Users.Remove(productInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        }
    }

