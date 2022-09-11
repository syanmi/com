
namespace CommTerminal.Command
{
    public interface ICommand<out TResult>
    {
    }

    public interface ICommand<out T1, in T2, out TResult> : ICommand<TResult>
    {
        T1 ToSendData();

        TResult Parse(T2 data);
    }
}
