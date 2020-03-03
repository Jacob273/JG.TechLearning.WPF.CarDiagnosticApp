using JG.TechLearning.WPF.CarDiagnostic.GlobalCommonTypes;
using System.Collections.ObjectModel;

namespace JG.TechLearning.WPF.CarDiagnostic.ViewModel
{
    public class LoggingViewModel : ViewModelBaseExt
    {
        public void Log(LogInfoItem logInformation)
        {
            LogCollection.Add(logInformation);
        }

        private ObservableCollection<LogInfoItem> logCollection = new ObservableCollection<LogInfoItem>();

        public ObservableCollection<LogInfoItem> LogCollection
        {
            get
            {
                return logCollection;
            }

            set
            {
                if (logCollection == value)
                {
                    return;
                }
                logCollection = value;
                RaisePropertyChanged(nameof(LogCollection));
            }
        }
    }
}
