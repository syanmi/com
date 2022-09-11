using System;
using CommTerminal.Command;
using CommTerminal.Communication;
using CommTerminal.DependencyInjection;
using CommTerminal.Test;
using Microsoft.Extensions.DependencyInjection;

namespace CommTerminal.Forms
{
    public partial class TestCommandEditor : AbstractCommandEditor
    {
        public TestCommandEditor()
        {
            InitializeComponent();
        }

        [Injection]
        public ITestService TestService { get; set; }

        private bool isbool = false;
        private void button1_Click(object sender, EventArgs e)
        {
            var comm = Services.GetRequiredService<SerialCommunication>();

            if (!isbool)
            {
                isbool = true;
                comm.Connected += (o, ev) => Console.WriteLine("connected!");
                comm.DisConnected += (o, ev) => Console.WriteLine("disconnected!");
            }

            comm.Open();
            
            var command = new TestCommand();
            var receiveStrData = Communication.Send(command);

            textBoxReceived.Text = receiveStrData;

            comm.Close();
        }
    }
}
