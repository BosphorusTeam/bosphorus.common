using Bosphorus.Common.Api.Enum.Registration;

namespace Bosphorus.Common.Api.Demo
{
    public class DefaultActions: IEnumerationRegistration<Action>
    {
        public static Action New = new Action() { Id = 1, Name = "New" };
        public static Action Open = new Action() { Id = 2, Name = "Open" };
    }
}
