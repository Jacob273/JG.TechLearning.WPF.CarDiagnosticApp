using JG.TechLearning.WPF.CarDiagnostic.GlobalCommonTypes;
using NLog;

namespace JG.TechLearning.WPF.CarDiagnostic.ViewModel
{
    public class MainViewModel : ViewModelBaseExt
    {
        private IWindowService _windowService;
        private ViewModelBaseExt _liveDataViewModel;
        private ViewModelBaseExt _applcationSettingsViewModel;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IVersionResolver versionResolver, IWindowService windowService, ViewModelBaseExt liveDataViewModel, ViewModelBaseExt applicationSettingsViewModel)
        {
            Title = $"Car diagnostic Application {versionResolver.GetVersion()}";
            LogManager.GetCurrentClassLogger().Warn($"~Starting up {Title}");
            _windowService = windowService;
            _liveDataViewModel = liveDataViewModel;
            _applcationSettingsViewModel = applicationSettingsViewModel;
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

        private RelayCommand _openApplicationSettingsCommand;
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

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand OpenApplicationSettingsCommand
        {
            get
            {
                return _openApplicationSettingsCommand ?? (_openApplicationSettingsCommand = new RelayCommand(
                           () =>
                           {

                               _windowService.ShowWindow(_applcationSettingsViewModel);
                           },
                           null));
            }
        }



    }
}