using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.Common.Clr.Demo
{
    public class CustomActions: IEnumerationRegistration<Action>
    {
        public static Action Verify = new Action {Id = 3, Name = "Verify"};
    }
}
