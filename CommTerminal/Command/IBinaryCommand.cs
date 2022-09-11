
namespace CommTerminal.Command
{
    public interface IBinaryCommand<out T> : ICommand<byte[], byte[], T>
    {
    }
}
