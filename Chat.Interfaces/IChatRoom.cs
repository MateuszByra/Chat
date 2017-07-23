using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IChatRoom
    {
        IChatRoomLabel Label { get; set; }
        List<IChatRoomMessage> Messages { get; set; }
        HashSet<string> VisitorsNames { get; set; }
    }
}
