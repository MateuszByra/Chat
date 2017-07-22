using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IChatRoomLogic
    {
        bool Add(string roomName, string owner);
        bool Exists(string roomName);
        IEnumerable<IChatRoomLabel> GetChatRoomsLabels();
        IChatRoom GetChatRoom(int id);
    }
}
