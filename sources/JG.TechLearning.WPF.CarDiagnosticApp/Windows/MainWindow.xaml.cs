using System;
using System.Windows;

namespace JG.TechLearning.WPF.CarDiagnosticApp.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            App.Current.Shutdown();
        }
    }
}
