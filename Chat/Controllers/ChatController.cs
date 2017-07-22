using Chat.Common;
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

        }

        public ChatController(INamesLogic namesLogic)
        {
            this.namesLogic = ChatFactory.CreateNamesLogic();//namesLogic;
        }

        // GET: Chat
        public void StartDialog(string name)
        {
            if (namesLogic.Add(name))
            {
                Session["name"] = name;
                Response.Redirect("Index");
            }
            RedirectToStartPage();
        }

        [HttpPost]
        public bool ValidateName(string name)
        {
            if (ModelState.IsValid)
            {
                return NamesValidator.Exists(name);
            }
            return false;
        }

        public ActionResult Index()
        {
            if (Session["name"] == null)//jesli użytkownik nie ma przypisanego loginu
                RedirectToStartPage();
            return View();
        }

        /// <summary>
        /// Przekierowanie na stronę startową aplikacji.
        /// </summary>
        private void RedirectToStartPage()
        {
            Response.Redirect("/Home/Index");
        }
    }
}