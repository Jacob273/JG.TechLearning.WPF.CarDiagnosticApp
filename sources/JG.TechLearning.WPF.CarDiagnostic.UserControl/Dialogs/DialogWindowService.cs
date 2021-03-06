﻿using JG.TechLearning.WPF.CarDiagnostic.Common.Interfaces;

namespace JG.TechLearning.WPF.CarDiagnostic.UserControlNS.Dialogs
{
    public class DialogWindowService : IWindowService
    {
        public void ShowWindow(object viewModel)
        {
            var win = new DialogWindow();
            win.Content = viewModel;
            win.ShowDialog();
        }
    }
}
