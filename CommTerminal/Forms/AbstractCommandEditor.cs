using CommTerminal.Communication;
using CommTerminal.DependencyInjection;

namespace CommTerminal.Forms
{
    public partial class AbstractCommandEditor : ServiceInjectUserControl
    {
        public AbstractCommandEditor()
        {
            InitializeComponent();
        }
        
        [Injection]
        public ICommunication Communication { get; set; }
    }
}
