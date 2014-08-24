using System.Diagnostics;
using Bosphorus.Common.Clr.Common;

namespace Bosphorus.Common.Clr.Diagnostic
{
    public static class DebugEx
    {
        private static readonly DumpSettings dumpSettings;

        static DebugEx()
        {
            dumpSettings = new DumpSettings {MaxDepth = 1};
        }

        [Conditional("DEBUG")]
        public static void Log(string messageFormat, params object[] parameters)
        {
            object[] parmetersDump = BuildParametersDump(parameters);
            string message = string.Format(messageFormat, parmetersDump);
            Debug.WriteLine(message);
        }

        private static string[] BuildParametersDump(object[] parameters)
        {
            string[] result = new string [parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                object parameter = parameters[i];
                string dump = ObjectDumper.ToDump(parameter, string.Empty, dumpSettings);
                result[i] = dump;
            }

            return result;
        }
    }
}
