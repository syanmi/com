using System;
using System.Windows.Forms;
using CommTerminal.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace CommTerminal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(IServiceCollection services)
        {
            InitializeComponent();

            var provider = services.BuildServiceProvider();

            foreach (var control in Controls)
            {
                if (control is AbstractCommandEditor editor)
                {
                    editor.Services = provider;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
