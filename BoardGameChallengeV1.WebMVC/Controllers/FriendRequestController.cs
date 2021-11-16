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
    public class FriendRequestController : Controller
    {
        private readonly Guid _userId;

        public FriendRequestController(Guid userId)
        {
            _userId = userId;
        }

        // GET: Friend
        public ActionResult Index()
        {
            var service = CreateFriendRequestService();
            var model = service.GetFriendRequestsByUserId(_userId);
            return View(model);
        }

        // GET: FriendRequest By FriendRequestId
        public ActionResult Details(int friendRequestId)
        {
            var service = CreateFriendRequestService();
            var model = service.GetFriendRequestByFriendRequestId(friendRequestId);
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
        public ActionResult Edit(int friendRequestId)
        {
            var service = CreateFriendRequestService();
            var detail = service.GetFriendRequestByFriendRequestId(friendRequestId);
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
        public ActionResult Edit(FriendRequestEdit model)
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
        public ActionResult Delete(int friendRequestId)
        {
            var service = CreateFriendRequestService();
            var model = service.GetFriendRequestByFriendRequestId(friendRequestId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteFriendRequest(int friendRequestId)
        {
            var service = CreateFriendRequestService();
            service.DeleteFriendRequest(friendRequestId);
            return RedirectToAction("Index");
        }
    }
}