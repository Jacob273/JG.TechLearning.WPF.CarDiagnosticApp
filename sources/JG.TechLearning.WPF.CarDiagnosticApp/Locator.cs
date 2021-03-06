﻿using System.Windows;
using JG.TechLearning.WPF.CarDiagnostic.ViewModel;
using JG.TechLearning.WPF.CarDiagnosticApp.IoC;

namespace JG.TechLearning.WPF.CarDiagnosticApp
{
    public class Locator
    {
        public MainViewModel MainViewModel
        {
            get
            {
                return IoCKernel.Get<MainViewModel>();
            }
        }

        public ProgressBarViewModel ProgressBarViewModel
        {
            get
            {
                return IoCKernel.Get<ProgressBarViewModel>();
            }
        }

        public LiveDataViewModel LiveDataViewModel
        {
            get
            {
                return IoCKernel.Get<LiveDataViewModel>();
            }
        }

        public ApplicationSettingsViewModel ApplicationSettingsViewModel
        {
            get
            {
                return IoCKernel.Get<ApplicationSettingsViewModel>();

            }
        }

        public LoggingViewModel LoggingViewModel
        {
            get
            {
                return IoCKernel.Get<LoggingViewModel>();
            }
        }
    }
}
