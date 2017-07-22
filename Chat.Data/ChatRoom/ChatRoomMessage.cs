using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.ChatRoom
{
    public class ChatRoomMessage : IChatRoomMessage
    {
        public string Owner { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
