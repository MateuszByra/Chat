using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IChatRoomLabel
    {
        /// <summary>
        /// Nr porządkowy
        /// </summary>
         int Id { get; set; }
        /// <summary>
        /// Nazwa pokoju
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Założyciel pokoju
        /// </summary>
         string Owner { get; set; }
        /// <summary>
        /// Flaga określająca, czy pokój z nową wiadomością został odwiedzony
        /// </summary>
        bool Visited { get; set; }
    }
}
