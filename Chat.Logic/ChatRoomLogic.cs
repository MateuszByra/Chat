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
       // public Func<ChatRoomsLabelsList> GetChatRoomsLabelsFunc;

        public Func<List<IChatRoom>> GetChatRoomsFunc;
        /// <summary>
        /// Dodanie nowego pokoju do listy
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public bool Add(string roomName, string owner)
        {
            if (string.IsNullOrEmpty(roomName) || string.IsNullOrEmpty(owner) || Exists(roomName))
            {
                return false;
            }

            //GetChatRoomsLabelsFunc().Add(CreateChatRoomLabel(roomName, owner));
            GetChatRoomsFunc().Add(CreateChatRoom(roomName, owner));
            return true;
        }

        public bool Exists(string roomName)
        {
            return GetChatRooms().Select(x=>x.Label).Any(x => x.Name.Equals(roomName, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Pobiera wszystkie etykiety pokoi
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IChatRoomLabel> GetChatRoomsLabels()
        {
            return GetChatRooms().Select(x => SetVisited(x).Label);
        }

        /// <summary>
        /// Tworzy etykietę chatu
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        private IChatRoomLabel CreateChatRoomLabel(string roomName, string owner)
        {
            var list = GetChatRoomsLabels().ToList();
            var id = list.Count + 1;
            return new ChatRoomLabel() { Id = id, Name = roomName, Owner = owner };
        }

        private IChatRoom CreateChatRoom(string roomName, string owner)
        {
            return new ChatRoom() { Label = CreateChatRoomLabel(roomName, owner) };
        }

        /// <summary>
        /// Pobiera chat
        /// </summary>
        /// <param name="id"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public IChatRoom GetChatRoom(int id, string requesterName)
        {
            var chatRoom = GetChatRooms().FirstOrDefault(x => x.Label.Id == id);
            chatRoom.Label.Visited = true;
            chatRoom.VisitorsNames.Add(requesterName);
            //SetVisited(requesterName, chatRoom);
            return chatRoom;
        }

        /// <summary>
        /// Zapisuje wiadomość do czatu
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        public void SaveMessage(int roomId, string owner, string message)
        {
            var room = GetChatRooms().FirstOrDefault(x => x.Label.Id == roomId);
            room.VisitorsNames.RemoveWhere(x => !x.Equals(owner, StringComparison.CurrentCultureIgnoreCase));
            room.Messages.Add(new ChatRoomMessage() { Owner = owner, Message = message, Time = DateTime.Now });
        }

        private List<IChatRoom> GetChatRooms()
        {
            if (GetChatRoomsFunc == null)
            {
                throw new InvalidOperationException("Func GetChatRoomsFunc nie jest ustawiony.");
            }
            return GetChatRoomsFunc();
        }

        private IChatRoom SetVisited(IChatRoom room)
        {
            room.Label.Visited =
                !room.Messages.Any();//||
                //room.Messages.Last().Owner.Equals(requesterName, StringComparison.CurrentCultureIgnoreCase);
               // || room.VisitorsNames.Contains(requesterName);
            return room;// GetChatRooms().FirstOrDefault(x => x.Label.Id == roomId).Label.Visited = visited;
        }

        public bool WasVisitedBy(string requesterName, int chatId)
        {
            var room = GetChatRooms().FirstOrDefault(x => x.Label.Id == chatId);
            if (room == null)
                return false;
            var visited= !room.Messages.Any() || room.Messages.Last().Owner.Equals(requesterName, StringComparison.CurrentCultureIgnoreCase)
             || room.VisitorsNames.Contains(requesterName);
            return visited;
        }
    }
}
