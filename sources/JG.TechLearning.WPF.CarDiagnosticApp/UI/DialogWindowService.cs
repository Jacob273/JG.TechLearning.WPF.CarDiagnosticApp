using JG.TechLearning.WPF.CarDiagnosticApp.Windows;
using System.Windows;

namespace JG.TechLearning.WPF.CarDiagnosticApp.UI
{
    public class DialogWindowService : IWindowService
    {
        public void ShowWindow(object viewModel)
        {
            var win = new DialogWindow();
            win.Content = viewModel;
            win.Show();
        }
    }
}
