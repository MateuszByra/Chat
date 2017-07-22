using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.ChatRoom
{
    /// <summary>
    /// Lista etykie pokoi
    /// </summary>
    public class ChatRoomsLabelsList : List<IChatRoomLabel>
    {
        //private List<IChatRoomLabel> roomsLabels;

        //public ChatRoomsLabelsList()
        //{
        //    roomsLabels = new List<IChatRoomLabel>();
        //}

        public void SetStartupChatRoomsLabelsList(List<IChatRoomLabel> startupLabels)
        {
            //roomsLabels = startupLabels;
            this.AddRange(startupLabels);
        }
    }
}
