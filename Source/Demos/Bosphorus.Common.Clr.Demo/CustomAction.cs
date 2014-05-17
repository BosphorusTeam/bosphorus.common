namespace Bosphorus.Common.Clr.Demo
{
    public class CustomAction: Action
    {
        public static CustomAction Verify = Create<CustomAction>(3, "Verify");
    }
}
