﻿using Chat.Common;
using Chat.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Controllers
{
    public class ChatController : Controller
    {
        private readonly INamesLogic namesLogic;

        public ChatController()
        {
            this.namesLogic = ChatFactory.CreateNamesLogic();//namesLogic;
        }

        public ActionResult Index()
        {
            if (Session["name"] == null)//jesli użytkownik nie ma przypisanego loginu
                return RedirectToStartPage();
            return View();
        }

        [HttpPost]
        public ActionResult StartDialog(string name)
        {
            if (namesLogic.Add(name))
            {
                Session["name"] = name;
                return Redirect("Index");
            }
            return RedirectToStartPage();
        }

        [HttpPost]
        public bool ValidateName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return namesLogic.Exists(name);
            }
            return false;
        }

        /// <summary>
        /// Przekierowanie na stronę startową aplikacji.
        /// </summary>
        private ActionResult RedirectToStartPage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}