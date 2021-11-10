using BoardGameChallengeV1.Models;
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
        // GET: Play
        public ActionResult Index()
        {
            var model = new PlayList[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}