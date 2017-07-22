using Chat.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Logic
{
    public class NamesLogic : INamesLogic
    {
        /// <summary>
        /// Zwraca aktualną listę nazw użytkowników.
        /// </summary>
        public Func<NamesList> GetNamesList;

        public bool Add(string name)
        {
            if (Exists(name))
                return false;
            GetNamesList().Add(name);
            return true;
        }

        public bool Exists(string name)
        {
            return GetNamesList().Exists(x=>x.Equals(name,StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
