using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Logic
{
    public class NamesList : List<string>
    {
        private static List<string> names = new List<string>();

        //public bool Exists(string name)
        //{
        //    return names.Exists(x => x.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        //}
    }
}
