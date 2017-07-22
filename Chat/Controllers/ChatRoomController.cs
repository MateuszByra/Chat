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
            var labels = ChatRoomConversionHelper.ChatRoomLabelsToViewModel(chatRoomLogic.GetChatRoomsLabels());
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
            var room = chatRoomLogic.GetChatRoom(id);
            if (room == null)
            {
                return Redirect("/Home/index");
            }
            var result = ChatRoomConversionHelper.ChatRoomMessagesToViewModel(room.Messages);
            return View(result);
        }

        [HttpPost]
        public void SaveMessage(string message)
        {
            int id;
            int.TryParse(Request.UrlReferrer.Segments.Last().ToString(), out id);
            chatRoomLogic.SaveMessage(id, Session["name"] as string, message);
        }

        [HttpGet]
        public ActionResult GetChatRoomMessagesTable()
        {
            int chatRoomId;
            int.TryParse(Request.UrlReferrer.Segments.Last().ToString(), out chatRoomId);
            var messages = ChatRoomConversionHelper.ChatRoomMessagesToViewModel(chatRoomLogic.GetChatRoom(chatRoomId).Messages);
            return PartialView("~/Views/Shared/MessagesTable.cshtml", messages);
        }
    }
}