using Chat.Data;
using Chat.Data.ChatRoom;
using Chat.Interfaces;
using Chat.Logic;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Common
{
    public static class ChatFactory
    {
        private static NamesList namesList;

        public static NamesList NamesList => namesList ?? (namesList = new NamesList());

        private static ChatRoomsLabelsList chatRoomsLabelsList;

        public static ChatRoomsLabelsList ChatRoomsLabelsList
        {
            get
            {
                if (chatRoomsLabelsList == null)
                {
                    chatRoomsLabelsList = new ChatRoomsLabelsList();
                    chatRoomsLabelsList.SetStartupChatRoomsLabelsList(GetPredefinedRooms().Select(x => x.Label).ToList());
                }
                return chatRoomsLabelsList;
            }
        }

        private static List<IChatRoom> chatRooms;
        public static List<IChatRoom> ChatRoomsList
        {
            get
            {
                if (chatRooms == null)
                {
                    chatRooms = new List<IChatRoom>();
                    chatRooms.AddRange(GetPredefinedRooms());
                }
                return chatRooms;
            }
        }

        private static List<IChatRoom> GetPredefinedRooms()
        {
            var rooms = new List<IChatRoom>();
            rooms.Add(new ChatRoom() { Label = new ChatRoomLabel() { Id = 1, Name = "First room", Owner = "First owner" } });
            rooms.Add(new ChatRoom() { Label = new ChatRoomLabel() { Id = 2, Name = "Second room", Owner = "Second owner" } });
            return rooms;

        }

        #region logiki
        private static INamesLogic namesLogic;

        public static INamesLogic CreateNamesLogic()
        {
            return namesLogic ?? (namesLogic = new NamesLogic() { GetNamesListFunc = () => NamesList });
        }

        private static IChatRoomLogic chatRoomLogic;

        public static IChatRoomLogic CreateChatRoomLogic()
        {
            return chatRoomLogic ?? (chatRoomLogic = new ChatRoomLogic() { GetChatRoomsFunc = () => ChatRoomsList });
        }
        #endregion
    }
}
