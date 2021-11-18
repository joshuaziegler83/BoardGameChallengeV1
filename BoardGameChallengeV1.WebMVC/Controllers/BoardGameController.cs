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
    public class BoardGameController : Controller
    {
        // GET: BoardGame
        public ActionResult Index()
        {
            var service = CreateBoardGameService();
            var model = service.GetAllBoardGames();
            return View(model);
        }

        // GET: BoardGameById

        public ActionResult Details(int id)
        {
            var service = CreateBoardGameService();
            var model = service.GetBoardGameById(id);
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoardGameCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateBoardGameService();
            if (service.CreateBoardGame(model))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "You suck at this!");
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBoardGameService();
            var detail = service.GetBoardGameById(id);
            var model = new BoardGameEdit
            {
                BoardGameId = detail.BoardGameId,
                UserId = detail.UserId,
                Name = detail.Name,
                Rating = detail.Rating,
                TimesPlayed = detail.TimesPlayed
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BoardGameEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateBoardGameService();
            if (service.UpdateBoardGame(model))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "You suck at this!");
                return View(model);
            }
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateBoardGameService();
            var model = service.GetBoardGameById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteBoardGames(int id)
        {
            var service = CreateBoardGameService();
            service.DeleteBoardGame(id);
            return RedirectToAction("Index");
        }

        private BoardGameService CreateBoardGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BoardGameService(userId);
            return service;
        }
    }
}