using GalaSoft.MvvmLight.Messaging;
using JG.TechLearning.WPF.CarDiagnosticApp.IoC;
using JG.TechLearning.WPF.CarDiagnosticApp.Enums;
using JG.TechLearning.WPF.CarDiagnosticApp.Messages;
using JG.TechLearning.WPF.CarDiagnosticApp.Windows;
using System.Windows;
using NLog.Config;
using NLog;

namespace JG.TechLearning.WPF.CarDiagnosticApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ProgressWindow progressWindow;
        private MainWindow mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            IoCKernel.Initialize(new AppModule());
            progressWindow = IoCKernel.Get<ProgressWindow>();
            progressWindow.Show();
            Messenger.Default.Send(new IndicateProgressMessage() { OnLoadingEndedCallback = OnLoadingEnded });
            LogManager.Configuration = IoCKernel.Get<LoggingConfiguration>();
            base.OnStartup(e);
        }

        private void OnLoadingEnded(ProgressResult result)
        {
            Dispatcher.Invoke(() =>
            {
                switch (result)
                {
                    case ProgressResult.Failed:
                        //todo: handle loading process failure
                        break;
                    case ProgressResult.Success:
                        progressWindow.Hide();
                        mainWindow = new MainWindow();
                        mainWindow.Show();
                        break;
                }
            });
        }
    }
}
