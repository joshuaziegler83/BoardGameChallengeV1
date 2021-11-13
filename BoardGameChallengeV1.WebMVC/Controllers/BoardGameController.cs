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
        private readonly Guid _userId;

        public BoardGameController(Guid userId)
        {
            _userId = userId;
        }

        // GET: BoardGame
        public ActionResult Index()
        {
            var service = CreateBoardGameService();
            var model = service.GetAllBoardGames();
            return View(model);
        }

        // GET: BoardGameById

        public ActionResult Details(int boardGameId)
        {
            var service = CreateBoardGameService();
            var model = service.GetBoardGameById(boardGameId);
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

        [HttpGet]
        public ActionResult Edit(int boardGameId)
        {
            var service = CreateBoardGameService();
            var detail = service.GetBoardGameById(boardGameId);
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
        public ActionResult Edit(BoardGameEdit model)
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
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int boardGameId)
        {
            var service = CreateBoardGameService();
            var model = service.GetBoardGameById(boardGameId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteBoardGames(int boardGameId)
        {
            var service = CreateBoardGameService();
            service.DeleteBoardGame(boardGameId);
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