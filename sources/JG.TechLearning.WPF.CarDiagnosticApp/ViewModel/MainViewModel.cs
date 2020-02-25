using JG.TechLearning.WPF.CarDiagnosticApp.Commands;
using JG.TechLearning.WPF.CarDiagnosticApp.UI;
using JG.TechLearning.WPF.CarDiagnosticApp.Version;
using NLog;

namespace JG.TechLearning.WPF.CarDiagnosticApp.ViewModel
{
    public class MainViewModel : ViewModelBaseExt
    {
        private IWindowService _windowService;
        private ViewModelBaseExt _liveDataViewModel;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IVersionResolver versionResolver, IWindowService windowService, ViewModelBaseExt liveDataViewModel)
        {
            Title = $"Car diagnostic Application {versionResolver.GetVersion()}";
            LogManager.GetCurrentClassLogger().Warn($"~Starting up {Title}");
            _windowService = windowService;
            _liveDataViewModel = liveDataViewModel;
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

                        _windowService.ShowWindow(_liveDataViewModel);
                    },
                    null));
            }
        }

    }
}