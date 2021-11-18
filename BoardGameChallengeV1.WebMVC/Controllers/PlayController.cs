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
    public class PlayController : Controller
    {
        private readonly Guid _userId;

        public PlayController(Guid userId)
        {
            _userId = userId;
        }

        // GET: Play
        public ActionResult Index()
        {
            var service = CreatePlayService();
            var model = service.GetPlaysByUserId(_userId);
            return View(model);
        }

        // GET: Play By BoardGameId
        public ActionResult GetPlaysByBoardGameId(int id)
        {
            var service = CreatePlayService();
            var model = service.GetPlaysByBoardGameId(id);
            return View(model);
        }

        // GET: Details By PlayId
        public ActionResult Details(int id)
        {
            var service = CreatePlayService();
            var model = service.GetPlaysByBoardGameId(id);
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePlayService();
            if (service.CreatePlay(model))
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
            var service = CreatePlayService();
            var detail = service.GetPlay(id);
            var model = new PlayEdit
            {
                PlayId = detail.PlayId,
                UserId = detail.UserId,
                BoardGameId = detail.BoardGameId,
                Review = detail.Review,
                IsReviewPrivate = detail.IsReviewPrivate,
                Rating = detail.Rating
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePlayService();
            if (service.UpdatePlay(model))
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
            var service = CreatePlayService();
            var model = service.GetPlay(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePlay(int id)
        {
            var service = CreatePlayService();
            service.DeletePlay(id);
            return RedirectToAction("Index");
        }

        private PlayService CreatePlayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayService(userId);
            return service;
        }
    }
}