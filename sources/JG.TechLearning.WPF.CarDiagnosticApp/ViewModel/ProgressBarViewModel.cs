using JG.TechLearning.WPF.CarDiagnosticApp.Enums;
using JG.TechLearning.WPF.CarDiagnosticApp.Messages;
using JG.TechLearning.WPF.CarDiagnosticApp.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JG.TechLearning.WPF.CarDiagnosticApp.ViewModel
{
    public class ProgressBarViewModel : ViewModelBaseExt
    {
        public ProgressBarViewModel()
        {
            LogFileCollection.Add(new LogInfoItem("Starting application...", LogInfoSeverity.Error));
            LogFileCollection.Add(new LogInfoItem("Please wait...", LogInfoSeverity.Info));
            LogFileCollection.Add(new LogInfoItem("...", LogInfoSeverity.Warning));
            LogFileCollection.Add(new LogInfoItem("...", LogInfoSeverity.Unknown));

            MessengerInstance.Register<IndicateProgressMessage>(this, OnIndicateProgress);
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

        private ObservableCollection<LogInfoItem> logFileCollection = new ObservableCollection<LogInfoItem>();

        public ObservableCollection<LogInfoItem> LogFileCollection
        {
            get
            {
                return logFileCollection;
            }

            set
            {
                if (logFileCollection == value)
                {
                    return;
                }
                logFileCollection = value;
                RaisePropertyChanged(nameof(LogFileCollection));
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
                message?.OnLoadingEndedCallback(Enums.ProgressResult.Success);
            });

        }
    }
}
