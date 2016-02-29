using Bosphorus.Common.Api.Enum.Registration;

namespace Bosphorus.Common.Api.Demo
{
    public class CustomActions: IEnumerationRegistration<Action>
    {
        public static Action Verify = new Action {Id = 3, Name = "Verify"};
    }
}
