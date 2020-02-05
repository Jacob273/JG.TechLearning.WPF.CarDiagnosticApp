using GalaSoft.MvvmLight;
using JG.TechLearning.WPF.CarDiagnosticApp.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JG.TechLearning.WPF.CarDiagnosticApp.ViewModel
{
    public class ProgressBarViewModel : ViewModelBase
    {
        public ProgressBarViewModel()
        {
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
