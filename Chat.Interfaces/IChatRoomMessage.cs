using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IChatRoomMessage
    {
        string Owner { get; set; }
        string Message { get; set; }
        DateTime Time { get; set; }
    }
}
