using System;
using CommTerminal.Command;

namespace CommTerminal.Communication
{
    public interface ICommunication
    {
        event EventHandler Connected;
        event EventHandler DisConnected;
        void Open();
        void Close();
        TResult Send<TResult>(ICommand<TResult> command);
    }
}
