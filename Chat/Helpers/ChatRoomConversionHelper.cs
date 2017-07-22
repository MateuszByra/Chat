using Chat.Interfaces;
using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Helpers
{
    public class ChatRoomConversionHelper
    {
        public static ChatRoomLabelViewModelList ChatRoomLabelsToViewModel(IEnumerable<IChatRoomLabel> dataModels)
        {
            var result = new ChatRoomLabelViewModelList();
            foreach (var item in dataModels)
            {
                result.Add(new ChatRoomLabelViewModel() { GetLabelFunc = () => item });
            }
            return result;
        }

        public static List<ChatRoomMessageViewModel> ChatRoomMessagesToViewModel(IEnumerable<IChatRoomMessage> chatRoomMessages)
        {
            var result = new List<ChatRoomMessageViewModel>();
            foreach (var message in chatRoomMessages)
            {
                result.Add(new ChatRoomMessageViewModel() { GetMessageFunc = () => message });
            }
            return result;
        }
    }
}