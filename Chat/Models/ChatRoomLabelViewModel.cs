using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class ChatRoomLabelViewModel
    {
        public Func<IChatRoomLabel> GetLabelFunc;

        public IChatRoomLabel Label
        {
            get
            {
                if (GetLabelFunc == null)
                {
                    throw new InvalidOperationException("Brak ustawionej funkcji GetLabel");
                }
                return GetLabelFunc();
            }
        }
    }
}