using Chat.Common;
using Chat.Helpers;
using Chat.Interfaces;
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

        [HttpPost]
        public ActionResult GoToRoomsList(string name)
        {
            if (namesLogic.Add(name))
            {
                Session["name"] = name;
                return RedirectToAction("ChatRoomsList", "ChatRoom");
            }
            return RedirectToStartPage();
        }

        [HttpGet]
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

        public ActionResult LogOut()
        {
            var name = Session["name"] as string;
            if (name != null)
            {
                namesLogic.Remove(name);
                Session.Remove("name");
            }
            return RedirectToStartPage();
        }
    }
}