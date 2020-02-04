using GalaSoft.MvvmLight;
using JG.TechLearning.WPF.CarDiagnosticApp.Version;

namespace JG.TechLearning.WPF.CarDiagnosticApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IVersionResolver versionResolver)
        {
            Title = $"Car diagnostic Application {versionResolver.GetVersion()}";
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
    }
}