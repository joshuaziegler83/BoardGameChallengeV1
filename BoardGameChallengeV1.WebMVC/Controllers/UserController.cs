using BoardGameChallengeV1.Models;
using BoardGameChallengeV1.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGameChallengeV1.WebMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly Guid _userId;

        public UserController(Guid userId)
        {
            _userId = userId;
        }

        // GET: User
        public ActionResult Index()
        {
            var service = CreateUserService();
            var model = service.GetUserByUserId(_userId);
            return View(model);
        }

        // GET: All Users
        public ActionResult GetAllUsers()
        {
            var service = CreateUserService();
            var model = service.GetAllUsers();
            return View(model);
        }

        // GET: Details By PlayId
        public ActionResult Details(Guid userId)
        {
            var service = CreateUserService();
            var model = service.GetUserByUserId(userId);
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateUserService();
            if (service.CreateUser(model))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "You suck at this!");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid userId)
        {
            var service = CreateUserService();
            var detail = service.GetUser(userId);
            var model = new UserEdit
            {
                UserId = detail.UserId,
                FirstName = detail.FirstName,
                LastName = detail.LastName
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateUserService();
            if (service.UpdateUser(model))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "You suck at this!");
                return View(model);
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(Guid userId)
        {
            var service = CreateUserService();
            var model = service.GetUser(userId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteUser(Guid userId)
        {
            var service = CreateUserService();
            service.DeleteUser(userId);
            return RedirectToAction("Index");
        }

        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            return service;
        }
    }
}