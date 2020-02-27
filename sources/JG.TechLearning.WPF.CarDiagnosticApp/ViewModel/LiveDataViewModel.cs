using GalaSoft.MvvmLight;
using JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS;
using System;
using System.Linq;

namespace JG.TechLearning.WPF.CarDiagnosticApp.ViewModel
{
    public class LiveDataViewModel : ViewModelBaseExt
    {
        private IDataSource _carsDataSource;
        public LiveDataViewModel(IDataSource carsDataSource)
        {
            _carsDataSource = carsDataSource;
            RegisterOnDataSpeedValueChange();
        }

        private double _speedValue = 60;

        /// <summary>
        /// Sets and gets the SpeedValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double SpeedValue
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

        private void RegisterOnDataSpeedValueChange()
        {
            if(_carsDataSource == null)
            {
                return;
            }

            var speedValueData = _carsDataSource.Data
                                                .Select(x => x)
                                                .Where(x => x.Address.Equals("SpeedValue"))
                                                .FirstOrDefault();

            if(speedValueData != null)
            {
                SpeedValue = (double)speedValueData.Value;
                speedValueData.ValueChanged += OnSpeedValueChanged;
            }
        }

        private void OnSpeedValueChanged(object sender, object e)
        {
            SpeedValue = (double)e;
        }
    }
}
