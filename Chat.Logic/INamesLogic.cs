using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Logic
{
    public interface INamesLogic
    {
        bool Add(string name);
        bool Exists(string name);
        void Remove(string name);
    }
}
