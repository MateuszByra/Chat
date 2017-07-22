using Chat.Common;

namespace Chat.Logic
{
    public class NamesValidator
    {
        public static bool Exists(string name)
        {
            return ChatFactory.CreateNamesLogic().Exists(name);
        }
    }
}
