using Chat.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Common
{
    public static class ChatFactory
    {
        private static NamesList namesList;

        public static NamesList NamesList => namesList ?? (namesList = new NamesList());

        private static NamesLogic namesLogic;

        public static INamesLogic CreateNamesLogic()
        {
            return namesLogic ?? (namesLogic = new NamesLogic() { GetNamesList = () => NamesList });
        }
    }
}
