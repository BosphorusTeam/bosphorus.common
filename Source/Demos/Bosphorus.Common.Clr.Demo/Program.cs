using System;
using System.Collections.Generic;
using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.Common.Clr.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = Action.New;

            if (action == Action.New)
                Console.WriteLine("ok");

            IList<Action> customActionList = CustomAction.GetAll();

            IList<Action> actions = Action.GetAll();
            Action parsedAction1 = Action.Parse(1);
            Action parsedAction2 = Action.Parse("New");


            Console.WriteLine("ok");

            //Action[] enumerations = EnumerationExtensions.GetEnumerations(Action.New);
            //foreach (var enumeration in enumerations)
            //{
            //    Console.WriteLine(enumeration);
            //}

            //Action action = EnumerationExtensions.FromValue(Action.New, 1);
            //Console.WriteLine(action);

            //Action parsedAction = null;
            //EnumerationExtensions.TryParse(Action.New, 1, out parsedAction);
            //Console.WriteLine(parsedAction);
        }
    }
}
