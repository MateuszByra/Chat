using Chat.Common;
using Chat.Helpers;
using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Controllers
{
    [RequiredSessionName]
    public class ChatRoomController : Controller
    {
        private readonly IChatRoomLogic chatRoomLogic;

        public ChatRoomController()
        {
            chatRoomLogic = ChatFactory.CreateChatRoomLogic();
        }

        // GET: ChatRoom
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult ChatRoomsList()
        {
            var labels = ChatRoomLabelConversionHelper.ChatRoomLabelsToViewModel(chatRoomLogic.GetChatRoomsLabels());
            return View(labels);
        }

        [HttpPost]
        public ActionResult NewRoom(string roomName)
        {
            var owner = Session["name"] as string;
            chatRoomLogic.Add(roomName, owner);
            return RedirectToAction("ChatRoomsList");
        }

        public bool ValidateRoom(string roomName)
        {
            if (!string.IsNullOrEmpty(roomName))
            {
                return chatRoomLogic.Exists(roomName);
            }
            return false;
        }

        public ActionResult Chat(int id)
        {
            return View();
        }
    }
}