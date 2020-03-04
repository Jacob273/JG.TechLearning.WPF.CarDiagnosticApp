using JG.TechLearning.WPF.CarDiagnostic.GlobalCommonTypes;
using JG.TechLearning.WPF.CarDiagnostic.GlobalCommonTypes.Enums;
using JG.TechLearning.WPF.CarDiagnostic.MvvmMessages;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JG.TechLearning.WPF.CarDiagnostic.ViewModel
{
    public class ProgressBarViewModel : ViewModelBaseExt
    {
        public ProgressBarViewModel(LoggingViewModel loggingViewModel)
        {
            _loggingViewModel = loggingViewModel;
            _loggingViewModel.Log(new LogInfoItem("Loading application...", LogInfoSeverity.Info));
            _loggingViewModel.Log(new LogInfoItem("Please wait...", LogInfoSeverity.Info));
            MessengerInstance.Register<IndicateProgressMessage>(this, OnIndicateProgress);
        }


        private LoggingViewModel _loggingViewModel = null;

        /// <summary>
        /// Sets and gets the LoggingViewModel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LoggingViewModel LoggingViewModel
        {
            get
            {
                return _loggingViewModel;
            }

            set
            {
                if (_loggingViewModel == value)
                {
                    return;
                }

                _loggingViewModel = value;
                RaisePropertyChanged(nameof(LoggingViewModel));
            }
        }

        private double progressValue;

        public double ProgressValue
        {
            get
            {
                return progressValue;
            }

            set
            {
                if (Math.Abs(progressValue - value) < 10E-1)
                {
                    return;
                }
                progressValue = value;
                RaisePropertyChanged(nameof(ProgressValue));
            }
        }

        private async void OnIndicateProgress(IndicateProgressMessage message)
        {
                for (double i = 0; i <= 100; i += 10)
                {
                    ProgressValue = +i;
                    await Task.Delay(50);
                }

            await Task.Delay(1000).ContinueWith(
                (task) =>
            {
                message?.OnLoadingEndedCallback(ProgressResult.Success);
            });

        }
    }
}
