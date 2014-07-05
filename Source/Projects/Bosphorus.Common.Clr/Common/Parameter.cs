using System.Collections.Generic;
using System.Text;

namespace Bosphorus.Common.Clr.Common
{
    public class Parameter<TSignature>
        where TSignature : Parameter<TSignature>
    {
        private readonly StringBuilder messageBuilder;
        private readonly IDictionary<string, object> parameters;

        protected Parameter(string initialMessage)
        {
            messageBuilder = new StringBuilder(initialMessage);
            parameters = new Dictionary<string, object>();
        }

        public TSignature Add(string key, object value)
        {
            parameters.Add(key, value);
            return (TSignature) this;
        }

        public override string ToString()
        {
            string[] keys = new string[parameters.Count];
            parameters.Keys.CopyTo(keys, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                if (i == 0)
                    messageBuilder.Append(": [");

                string key = keys[i];
                object value = parameters[key];
                string postString = (i != keys.Length - 1) ? ", " : "]";

                messageBuilder.AppendFormat("{0}: {1}", key, value);
                messageBuilder.Append(postString);
            }

            return messageBuilder.ToString();
        }
    }
}
