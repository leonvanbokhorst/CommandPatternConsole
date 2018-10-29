namespace CommandPatternConsole.Interfaces
{
    public interface ICommandFactory
    {
        ICommand Create(string[] args);
    }
}