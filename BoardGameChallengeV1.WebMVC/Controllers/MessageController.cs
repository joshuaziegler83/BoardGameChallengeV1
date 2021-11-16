﻿using BoardGameChallengeV1.Models;
using BoardGameChallengeV1.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BoardGameChallengeV1.WebMVC.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
       
        private readonly Guid _userId;

        public MessageController(Guid userId)
        {
            _userId = userId;
        }

        // GET: Message
        public ActionResult Index()
        {
            var service = CreateMessageService();
            var model = service.GetMessagesByUserId(_userId);
            return View(model);
        }

        // GET: Message By MessageId
        public ActionResult GetMessagesByMessageId(int messageId)
        {
            var service = CreateMessageService();
            var model = service.GetMessageByMessageId(messageId);
            return View(model);
        }

        // GET: Details By MessageId
        public ActionResult Details(int messageId)
        {
            var service = CreateMessageService();
            var model = service.GetMessageByMessageId(messageId);
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMessageService();
            if (service.CreateMessage(model))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "You suck at this!");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int messageId)
        {
            var service = CreateMessageService();
            var detail = service.GetMessageByMessageId(messageId);
            var model = new MessageEdit
            {
                MessageId = detail.MessageId,
                UserId1 = detail.UserId1,
                UserId2 = detail.UserId2,
                Content = detail.Content,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MessageEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMessageService();
            if (service.UpdateMessage(model))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "You suck at this!");
                return View(model);
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int messageId)
        {
            var service = CreateMessageService();
            var model = service.GetMessageByMessageId(messageId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePlay(int messageId)
        {
            var service = CreateMessageService();
            service.DeleteMessage(messageId);
            return RedirectToAction("Index");
        }

        private MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userId);
            return service;
        }
    }
}