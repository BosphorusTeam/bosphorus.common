using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Bosphorus.Common.Clr.Diagnostic;
using Bosphorus.Common.Clr.Enum.Provider;

namespace Bosphorus.Common.Clr.Demo
{
    public class Program
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        private readonly IEnumerationProvider<Action> enumerationProvider;

        public Program(IEnumerationProvider<Action> enumerationProvider)
        {
            this.enumerationProvider = enumerationProvider;
        }

        public static void Main(string[] args)
        {
            Debug.WriteLine("denene", "Critical");

            OutputDebugString("ss");
            DebugEx.Log("Sample Log\n{0}\n{1}", typeof (Program), typeof (Program));


            Action verify = CustomActions.Verify;

            //string name = "Ounr EKER";
            //IEnumerable<string> parts = name.Split(2);
            //foreach (var part in parts)
            //{
            //    Console.WriteLine(part);
            //}

        }

        public void Run(string[] args)
        {
            IList<Action> actions = enumerationProvider.GetAll();

            Action action1 = enumerationProvider.Parse(1);
            if (action1 == DefaultActions.New)
                Console.WriteLine("ok");

            Action action2 = enumerationProvider.Parse("New");
            if (action2 == DefaultActions.New)
                Console.WriteLine("ok");

            //IList<Enumeration<int>> list = Action.GetAll();
            //Action parsedAction1 = (Action)Action.Parse(1);
            //Action parsedAction2 = (Action)Action.Parse("New");


            Console.WriteLine("ok");
        }
    }
}
