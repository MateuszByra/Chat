using Chat.Data.ChatRoom;
using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Logic
{
    class ChatRoomLogic : IChatRoomLogic
    {
        /// <summary>
        /// Zwraca aktualną listę etykiet pokoi.
        /// </summary>
        public Func<ChatRoomsLabelsList> GetChatRoomsLabelsFunc;

        public bool Add(string roomName, string owner)
        {
            if (string.IsNullOrEmpty(roomName) || string.IsNullOrEmpty(owner) || Exists(roomName))
            {
                return false;
            }

            GetChatRoomsLabelsFunc().Add(CreateChatRoomLabel(roomName, owner));
            return true;
        }

        public bool Exists(string roomName)
        {
            return GetChatRoomsLabels().Any(x => x.Name.Equals(roomName, StringComparison.CurrentCultureIgnoreCase));
        }

        public IEnumerable<IChatRoomLabel> GetChatRoomsLabels()
        {
            if (GetChatRoomsLabelsFunc == null)
            {
                throw new InvalidOperationException("Brak ustawionego fun GetChatRoomsLabelsFunc");
            }
            return GetChatRoomsLabelsFunc().OrderBy(x=>x.Id);
        }

        private IChatRoomLabel CreateChatRoomLabel(string roomName, string owner)
        {
            var list = GetChatRoomsLabels().ToList();
            var id = list.Count + 1;
            return new ChatRoomLabel() { Id = id, Name = roomName, Owner = owner };
        }
    }
}
