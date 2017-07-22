using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")] //by history back dzialalo poprawnie
        public ActionResult Index()
        {
            if (Session["name"] != null)//jeśli użytkownik jest już zalogowany
                return RedirectToAction("Index", "Chat");
            return View(new LoginName());
        }
    }
}