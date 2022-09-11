using System;
using System.Windows.Forms;
using CommTerminal.Communication;
using CommTerminal.Test;
using Microsoft.Extensions.DependencyInjection;

namespace CommTerminal
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IServiceCollection>(services)
                .AddSingleton<ICommunication, SerialCommunication>((x) => new SerialCommunication("COM5"))
                .AddSingleton<SerialCommunication>((x) => (SerialCommunication)x.GetRequiredService<ICommunication>())
                .AddTransient<ITestService, TestService>()
                .AddTransient<Form1>();
        }
    }
}
