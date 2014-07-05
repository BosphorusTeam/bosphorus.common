using Bosphorus.Common.Clr.Common;

namespace Bosphorus.Common.Clr.Diagnostic.Trace
{
    public class Method: Parameter<Method>
    {
        private Method(string initialMessage) 
            : base(initialMessage)
        {
        }

        public static Method Of(string name)
        {
            return new Method(name);
        }

        public Method Return(object value)
        {
            Add("@Return", value);
            return this;
        }
    }
}
