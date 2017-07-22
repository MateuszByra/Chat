using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface INamesLogic
    {
        bool Add(string name);
        bool Exists(string name);
        void Remove(string name);
    }
}
