using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommTerminal.Communication;

namespace CommTerminal.Command
{
    interface ICommandService<T> where T : ICommunication
    {


        void Open();
        void Close();

    }
}
