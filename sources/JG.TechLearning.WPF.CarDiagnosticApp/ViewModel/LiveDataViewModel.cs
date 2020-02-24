using GalaSoft.MvvmLight;

namespace JG.TechLearning.WPF.CarDiagnosticApp.ViewModel
{
    public class LiveDataViewModel : ViewModelBaseExt
    {
        private int _speedValue = 60;

        /// <summary>
        /// Sets and gets the SpeedValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SpeedValue
        {
            get
            {
                return _speedValue;
            }

            set
            {
                if (_speedValue == value)
                {
                    return;
                }

                _speedValue = value;
                RaisePropertyChanged(nameof(SpeedValue));
            }
        }
    }
}
