using System;
using System.Diagnostics;

namespace CommandPatternConsole
{
    public class GetCoffeeCommand : ICommand, ICommandFactory
    {
        public bool Milk { get; set; }
        public bool Sugar { get; set; }

        #region ICommand Members

        public string Name
        {
            get { return "GetCoffee"; }
        }

        public string Description
        {
            get { return "GetCoffee [milk] [sugar]"; }
        }

        public void Execute()
        {
            // Get some coffee
            Console.WriteLine(
                "Here's your coffee {0} milk and {1} sugar.",
                Milk ? "with" : "no",
                Sugar ? "with" : "no");

            // Log the command
            Debug.WriteLine(
                "{0}: {1} called",
                DateTime.Now,
                ToString());
        }

        #endregion

        #region ICommandFactory Members

        public ICommand Create(string[] args)
        {
            string arg1 = string.Empty;

            if (args.Length == 2)
            {
                arg1 = args[1];
            }

            string arg2 = string.Empty;

            if (args.Length == 3)
            {
                arg2 = args[2];
            }

            return new GetCoffeeCommand
                       {
                           Milk = (arg1 == "milk" ||
                                   (arg2 == "milk")),
                           Sugar = arg1 == "sugar" ||
                                   ((arg2 == "sugar"))
                       };
        }

        #endregion
    }
}