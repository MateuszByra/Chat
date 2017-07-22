using Chat.Data;
using Chat.Interfaces;
using System;

namespace Chat.Logic
{
    public class NamesLogic : INamesLogic
    {
        /// <summary>
        /// Zwraca aktualną listę nazw użytkowników.
        /// </summary>
        public Func<NamesList> GetNamesListFunc;

        public bool Add(string name)
        {
            if (string.IsNullOrEmpty(name) || Exists(name))
                return false;
            GetNamesList().Add(name);
            return true;
        }

        public bool Exists(string name)
        {
            return GetNamesList().Exists(x=>x.Equals(name,StringComparison.CurrentCultureIgnoreCase));
        }

        public void Remove(string name)
        {
            GetNamesList().Remove(name);
        }

        private NamesList GetNamesList()
        {
            if (GetNamesListFunc == null)
            {
                throw new InvalidOperationException("Brak ustawionego fun GetChatRoomsLabelsFunc");
            }
            return GetNamesListFunc();
        }
    }
}
