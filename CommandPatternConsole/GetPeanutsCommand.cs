using System;
using System.Diagnostics;

namespace CommandPatternConsole
{
    public class GetPeanutsCommand : ICommand, ICommandFactory
    {
        public int Ammount { get; set; }

        #region ICommand Members

        public string Name
        {
            get { return "GetPeanuts"; }
        }

        public string Description
        {
            get { return "GetPeanuts ammount"; }
        }

        public void Execute()
        {
            // Get some coffee
            Console.WriteLine(
                "There ya go: {0} peanuts.",
                Ammount);

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

            return new GetPeanutsCommand
                       {
                           Ammount = int.Parse(arg1)
                       };
        }

        #endregion
    }
}