using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.ChatRoom
{
    public class ChatRoomLabel : IChatRoomLabel
    {
        /// <summary>
        /// Id - nr porządkowy
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nazwa pokoju
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Założyciel pokoju
        /// </summary>
        public string Owner { get; set; }

        public bool Visited { get; set; }
    }
}
