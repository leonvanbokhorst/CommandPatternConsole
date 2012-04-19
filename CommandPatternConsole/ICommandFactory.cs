namespace CommandPatternConsole
{
    public interface ICommandFactory
    {
        ICommand Create(string[] args);
    }
}