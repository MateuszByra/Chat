using Chat.Data;
using Chat.Data.ChatRoom;
using Chat.Interfaces;
using Chat.Logic;
using System.Collections.Generic;

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
                if(chatRoomsLabelsList == null)
                {
                    chatRoomsLabelsList = new ChatRoomsLabelsList();
                    chatRoomsLabelsList.SetStartupChatRoomsLabelsList(GetPredefinedLabels());
                }
                return chatRoomsLabelsList;
            }
        }

        private static List<IChatRoomLabel> GetPredefinedLabels()
        {
            var roomsLabels = new List<IChatRoomLabel>();
            roomsLabels.Add(new ChatRoomLabel() { Id = 1, Name = "First room", Owner = "First owner" });
            roomsLabels.Add(new ChatRoomLabel() { Id = 2, Name = "Second room", Owner = "Second owner" });
            return roomsLabels;
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
            return chatRoomLogic ?? (chatRoomLogic = new ChatRoomLogic() { GetChatRoomsLabelsFunc = () => ChatRoomsLabelsList });
        }
        #endregion
    }
}
