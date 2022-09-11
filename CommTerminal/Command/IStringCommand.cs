
namespace CommTerminal.Command
{
    public interface IStringCommand<out T> : ICommand<string, string, T>
    {
    }
}
