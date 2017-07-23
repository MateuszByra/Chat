using Chat.Common;
using Chat.Helpers;
using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
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
        public string NewRoom(string roomName)
        {
            var owner = Session["name"] as string;

            if (string.IsNullOrEmpty(roomName))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //return Json(new { succcess = false, message = "Room name is required." });
                return "Room name is required.";
            }
            if (RoomExists(roomName))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return "This name already exists.";//Json(new { success = false, message = "This name already exists.." });
            }
            
            chatRoomLogic.Add(roomName, owner);
            Response.StatusCode = (int)HttpStatusCode.OK;
            return "OK";//Json(new { success = true, message=string.Empty });
        }

        public bool RoomExists(string roomName)
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

        [HttpGet]
        public ActionResult GetChatRoomsLabelsList()
        {
            var labels = ChatRoomConversionHelper.ChatRoomLabelsToViewModel(chatRoomLogic.GetChatRoomsLabels());
            return View("~/Views/Shared/ChatRoomsLabelsList.cshtml", labels);
        }
    }
}