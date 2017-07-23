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
            if (Session["name"] != null || !string.IsNullOrEmpty(Request.Cookies.Get("name")?.Value))//jeśli użytkownik jest już zalogowany
            {
                if (Session["name"] == null)
                {
                    Session["name"] = Request.Cookies.Get("name").Value; //ciastko w celu pamietania po wylaczeniu przegladarki. Porzucane dopiero w momencie wylogowania.
                }
                return RedirectToAction("ChatRoomsList", "ChatRoom");
            }
            

            return View(new LoginName());
        }
    }
}