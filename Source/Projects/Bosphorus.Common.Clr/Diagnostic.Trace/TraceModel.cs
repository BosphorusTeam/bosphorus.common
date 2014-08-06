namespace Bosphorus.Common.Clr.Diagnostic.Trace
{
    public class TraceModel
    {
        private readonly string message;
        private readonly object data;

        public TraceModel(string message, object data)
        {
            this.message = message;
            this.data = data;
        }

        public string Message
        {
            get { return message; }
        }

        public object Data
        {
            get { return data; }
        }

        public override string ToString()
        {
            string result = string.Format("{0}, [{1}]", message, data);
            return result;
        }
    }
}
