using System.Windows.Forms;
using CommTerminal.Communication;

namespace CommTerminal.Forms
{
    public partial class AbstractCommandEditorContainer : ServiceInjectUserControl
    {
        private ICommunication _communication;

        public AbstractCommandEditorContainer()
        {
            InitializeComponent();
        }

        public ICommunication Communication
        {
            get => _communication;
            set
            {
                _communication = value;
                foreach (var control in Controls)
                {
                    if (control is AbstractCommandEditor editor)
                    {
                        editor.Communication = value;
                    }
                }
            }
        }
    }
}
