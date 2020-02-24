using JG.TechLearning.WPF.CarDiagnosticApp.Commands;
using JG.TechLearning.WPF.CarDiagnosticApp.Version;
using NLog;

namespace JG.TechLearning.WPF.CarDiagnosticApp.ViewModel
{
    public class MainViewModel : ViewModelBaseExt
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IVersionResolver versionResolver)
        {
            Title = $"Car diagnostic Application {versionResolver.GetVersion()}";
            LogManager.GetCurrentClassLogger().Warn($"~Starting up {Title}");
        }

        private string _title;

        /// <summary>
        /// Sets and gets the Title property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title == value)
                {
                    return;
                }

                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private RelayCommand _openLiveDataCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand OpenLiveDataCommand
        {
            get
            {
                return _openLiveDataCommand ?? (_openLiveDataCommand = new RelayCommand(
                    () =>
                    {

                       
                            
                    },
                    null));
            }
        }

    }
}