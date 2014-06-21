using System;
using System.Collections.Generic;
using Bosphorus.BootStapper.Runner;
using Bosphorus.Common.Clr.Enum.Provider;

namespace Bosphorus.Common.Clr.Demo
{
    public class Program: IProgram
    {
        private readonly IEnumerationProvider<Action> enumerationProvider;

        public Program(IEnumerationProvider<Action> enumerationProvider)
        {
            this.enumerationProvider = enumerationProvider;
        }

        public static void Main(string[] args)
        {
            ConsoleRunner.Run<Program>(args);
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
