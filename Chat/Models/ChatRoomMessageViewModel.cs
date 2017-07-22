using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class ChatRoomMessageViewModel
    {
        public Func<IChatRoomMessage> GetMessageFunc;

        public IChatRoomMessage Message
        {
            get
            {
                if (GetMessageFunc == null)
                {
                    throw new InvalidOperationException("Brak ustawionej funkcji GetLabel");
                }
                return GetMessageFunc();
            }
        }
    }
}