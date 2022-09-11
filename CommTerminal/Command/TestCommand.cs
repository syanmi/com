using System.Text;

namespace CommTerminal.Command
{
    class TestCommand : IStringCommand<string>, IBinaryCommand<string>
    {
        public string ToSendData()
        {
            return "SendData";
        }

        public string Parse(string data)
        {
            return "Parse " + data;
        }

        byte[] ICommand<byte[], byte[], string>.ToSendData()
        {
            return Encoding.ASCII.GetBytes(ToSendData());
        }

        string ICommand<byte[], byte[], string>.Parse(byte[] data)
        {
            return Parse(Encoding.ASCII.GetString(data));
        }
    }
}
