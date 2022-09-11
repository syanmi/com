using System;
using System.Windows.Forms;
using CommTerminal.DependencyInjection;

namespace CommTerminal.Forms
{
    public partial class ServiceInjectUserControl : UserControl
    {
        private IServiceProvider _services;

        public ServiceInjectUserControl()
        {
            InitializeComponent();
        }

        public IServiceProvider Services
        {
            get => _services;
            set
            {
                _services = value;

                foreach (var control in Controls)
                {
                    if (control is ServiceInjectUserControl serviceInjectControl) serviceInjectControl.Services = value;
                }

                foreach (var prop in GetType().GetProperties())
                {
                    if (prop.GetCustomAttributes(typeof(InjectionAttribute), true).Length == 1)
                    {
                        var type = prop.PropertyType;
                        var obj = _services.GetService(type);
                        prop.SetValue(this, obj);
                    }
                }
            }
        }
    }
}
