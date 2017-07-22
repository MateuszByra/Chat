using Chat.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Logic.Validation
{
    public class NamesValidator
    {
        public static bool Exists(string name)
        {
            return ChatFactory.CreateNamesLogic().Exists(name);
        }
    }
}
