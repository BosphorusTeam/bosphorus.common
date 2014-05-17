using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.Common.Clr.Demo
{
    public class Action: Enumeration<Action>
    {
        public static Action New = new Action { Id = 1, Name = "New" };
        public static Action Open = new Action { Id = 2, Name = "Open" };
    }
}
