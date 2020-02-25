using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace JG.TechLearning.WPF.CarDiagnosticApp.UI
{
    public class WindowService : IWindowService
    {
        public void ShowWindow(object viewModel)
        {
            var win = new Window();
            win.Content = viewModel;
            win.Show();
        }
    }
}
