using System;
using System.Collections.Generic;
using System.Diagnostics;
using Bosphorus.Common.Clr.Common;
using Bosphorus.Common.Clr.Diagnostic.Trace;
using Bosphorus.Common.Clr.Enum.Provider;

namespace Bosphorus.Common.Clr.Demo
{
    public class Program
    {
        private readonly IEnumerationProvider<Action> enumerationProvider;

        public Program(IEnumerationProvider<Action> enumerationProvider)
        {
            this.enumerationProvider = enumerationProvider;
        }

        public static void Main(string[] args)
        {
            ITraceSourceBuilder traceSourceBuilder = new DefaultTraceSourceBuilder();
            TraceSource traceSource = traceSourceBuilder.Build("Deneme");
            traceSource.Info("Deneme", Method.Of("Main").Add("args", args));
            traceSource.Warning("Deneme", Method.Of("Main").Add("args", args));
            traceSource.Error("Deneme", Method.Of("Main").Add("args", args));

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
