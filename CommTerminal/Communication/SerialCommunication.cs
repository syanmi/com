using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using CommTerminal.Command;

namespace CommTerminal.Communication
{
    class SerialCommunication: ICommunication
    {
        private SerialPort _port;
        private Stream _stream;

        public event EventHandler Connected;
        public event EventHandler DisConnected;

        public SerialCommunication(string portName)
        {

            _port = new SerialPort();

            _port.PortName = portName;
            _port.BaudRate = 9600;
            _port.DataBits = 8;
            _port.Parity = Parity.None;
            _port.StopBits = StopBits.One;
            _port.Handshake = Handshake.None;
        }

        public void Open()
        {
            _port.Open();
            _stream = _port.BaseStream;
            if (Connected != null)
            {
                Connected(this, new EventArgs());
            }
        }

        public void Close()
        {
            _port.Close();
            if (DisConnected != null)
            {
                DisConnected(this, new EventArgs());
            }
        }
        public TResult Send<TResult>(ICommand<TResult> command)
        {
            if (command is IStringCommand<TResult> strCommand)
            {
                return Send(strCommand);
            }

            return default;
        }
        public T Send<T>(IStringCommand<T> command)
        {
            var sendData = command.ToSendData();
            var sendBytes = Encoding.ASCII.GetBytes(sendData);
            _stream.Write(sendBytes,0, sendBytes.Length);
            var receiveData =  Guid.NewGuid() + " : receiveData";

            return command.Parse(receiveData);
        }
        public T Send<T>(IBinaryCommand<T> command)
        {
            var sendData = command.ToSendData();

            Console.WriteLine(Encoding.ASCII.GetString(sendData));
            
            var receiveData = Encoding.ASCII.GetBytes("receiveBinaryData");

            return command.Parse(receiveData);
        }
    }
}
