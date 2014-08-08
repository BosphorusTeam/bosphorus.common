using System;
using System.Collections.Generic;
using System.Diagnostics;
using Bosphorus.Common.Clr.Common;
using Bosphorus.Common.Clr.Diagnostic.Trace;
using Bosphorus.Common.Clr.Enum.Provider;
using Bosphorus.Common.Clr.Extension;

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
            string name = "Ounr EKER";
            IEnumerable<string> parts = name.Split(2);
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }

            ITraceSourceBuilder traceSourceBuilder = new DefaultTraceSourceBuilder();
            TraceSource traceSource = traceSourceBuilder.Build("Program");
            traceSource.Listeners.Add(new EventLogTraceListener("ss"));

            //traceSource.TraceData(TraceEventType.Critical, 1, new TraceModel(){Message = "MEssaGE", Data = Method.Of("dd")});
            //traceSource.TraceData(TraceEventType.Critical, 1, );

            traceSource.Info("Message", Method.Of("Main").Add("args", args));
            traceSource.Warning("Message", new { Name = "Onur", Surname = "Eker" });
            //traceSource.Error("Message", Method.Of("Main").Add("args", args));

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
