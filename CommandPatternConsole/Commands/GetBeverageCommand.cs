using System;
using System.Diagnostics;
using CommandPatternConsole.Interfaces;

namespace CommandPatternConsole.Commands
{
    public class GetBeverageCommand : ICommand, ICommandFactory
    {
        public bool Sparkling { get; set; }

        #region ICommand Members

        public string Name
        {
            get { return "GetBeverage"; }
        }

        public string Description
        {
            get { return "GetBeverage [sparkling]"; }
        }

        public void Execute()
        {
            // Get some coffee
            Console.WriteLine(
                "Here's your drink {0} ",
                Sparkling ? "and it sparkles." : string.Empty);

            // Log the command
            Debug.WriteLine("{0}: {1} called",
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

            return new GetBeverageCommand
                       {
                           Sparkling = arg1 == "sparkling",
                       };
        }

        #endregion
    }
}