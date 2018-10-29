using System;
using System.Collections.Generic;
using CommandPatternConsole.Commands;
using CommandPatternConsole.Interfaces;

namespace CommandPatternConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IEnumerable<ICommand> commands = GetCommands();

            try
            {
                var parser = new CommandParser(commands);
                ICommand command = parser.Parse(args);
                command.Execute();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid command");
                PrintInstructions(commands);
            }

            Console.ReadKey();
        }

        private static IEnumerable<ICommand> GetCommands()
        {
            return new List<ICommand>
                       {
                           new GetBeverageCommand(),
                           new GetCoffeeCommand(),
                           new GetPeanutsCommand(),
                       };
        }

        private static void PrintInstructions(IEnumerable<ICommand> commands)
        {
            Console.WriteLine();
            Console.WriteLine("*** VENDING MACHINE commands ***");
            Console.WriteLine();

            foreach (ICommand command in commands)
            {
                Console.WriteLine("- {0}", command.Description);
            }

            Console.WriteLine();
        }
    }
}