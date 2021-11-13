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
    }
}