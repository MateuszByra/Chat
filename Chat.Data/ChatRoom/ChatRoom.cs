
using Chat.Interfaces;
using System.Collections.Generic;

namespace Chat.Data.ChatRoom
{
    public class ChatRoom : IChatRoom
    {
        public IChatRoomLabel Label { get; set; }
        public List<IChatRoomMessage> Messages { get; set; }
        public HashSet<string> VisitorsNames { get; set; }

        public ChatRoom()
        {
            Label = new ChatRoomLabel();
            Messages = new List<IChatRoomMessage>();
            VisitorsNames = new HashSet<string>();
        }
    }
}
