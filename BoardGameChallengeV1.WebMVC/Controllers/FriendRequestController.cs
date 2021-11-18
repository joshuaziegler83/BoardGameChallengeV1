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
    public class FriendRequestController : Controller
    {
        private readonly Guid _userId;

        // GET: Friend
        public ActionResult Index()
        {
            var service = CreateFriendRequestService();
            var model = service.GetFriendRequestsByUserId(_userId);
            return View(model);
        }

        // GET: FriendRequest By FriendRequestId
        public ActionResult Details(int id)
        {
            var service = CreateFriendRequestService();
            var model = service.GetFriendRequestByFriendRequestId(id);
            return View(model);
        }

        private FriendRequestService CreateFriendRequestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FriendRequestService(userId);
            return service;
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FriendRequestCreate model)
        {
            model.UserId1 = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFriendRequestService();
            if (service.CreateFriendRequest(model))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "You suck at this!");
                return View(model);
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var service = CreateFriendRequestService();
            var detail = service.GetFriendRequestByFriendRequestId(id);
            var model = new FriendRequestEdit
            {
                FriendRequestId = detail.FriendRequestId,
                UserId1 = detail.UserId1,
                UserId2 = detail.UserId2,
                IsAccepted = detail.IsAccepted,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FriendRequestEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFriendRequestService();
            if (service.UpdateFriendRequest(model))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "You suck at this!");
                return View(model);
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateFriendRequestService();
            var model = service.GetFriendRequestByFriendRequestId(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteFriendRequest(int id)
        {
            var service = CreateFriendRequestService();
            service.DeleteFriendRequest(id);
            return RedirectToAction("Index");
        }
    }
}