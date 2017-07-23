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

        public ActionResult ChatRoomsList()
        {
            var labels = ChatRoomConversionHelper.ChatRoomLabelsToViewModel(chatRoomLogic.GetChatRoomsLabels());
            return View(labels);
        }

        [HttpPost]
        public string NewRoom(string roomName)
        {
            if (string.IsNullOrEmpty(roomName))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return "Room name is required.";
            }
            if (RoomExists(roomName))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return "This name already exists.";
            }
            
            chatRoomLogic.Add(roomName, GetLoginName());
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
            var room = chatRoomLogic.GetChatRoom(id, GetLoginName());
            if (room == null)
            {
                return Redirect("/Home/index");
            }
            //chatRoomLogic.SetVisited(true, id);
            var result = ChatRoomConversionHelper.ChatRoomMessagesToViewModel(room.Messages);
            return View(result);
        }

        [HttpPost]
        public void SaveMessage(string message)
        {
            int id;
            int.TryParse(Request.UrlReferrer.Segments.Last().ToString(), out id);
            chatRoomLogic.SaveMessage(id, GetLoginName(), message);
            //chatRoomLogic.SetVisited(false,id);
        }

        [HttpGet]
        public ActionResult GetChatRoomMessagesTable()
        {
            int chatRoomId;
            int.TryParse(Request.UrlReferrer.Segments.Last().ToString(), out chatRoomId);
            
            var messages = ChatRoomConversionHelper.ChatRoomMessagesToViewModel(chatRoomLogic.GetChatRoom(chatRoomId, GetLoginName()).Messages);
            return PartialView("~/Views/Shared/MessagesTable.cshtml", messages);
        }

        [HttpGet]
        public ActionResult GetChatRoomsLabelsList()
        {
            var labels = ChatRoomConversionHelper.ChatRoomLabelsToViewModel(chatRoomLogic.GetChatRoomsLabels());
            return View("~/Views/Shared/ChatRoomsLabelsList.cshtml", labels);
        }

        private string GetLoginName()
        {
            return Session["name"] as string;
        }

        [HttpGet]
        public bool WasVisited(string chatRoomId)
        {
            if (string.IsNullOrEmpty(chatRoomId))
            {
                return false;
            }

            int id;
            int.TryParse(chatRoomId, out id);
            return chatRoomLogic.WasVisitedBy(GetLoginName(), id);
        }
    }
}