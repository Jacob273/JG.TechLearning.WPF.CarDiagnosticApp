using JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS;
using NLog;
using System;
using System.Linq;

namespace JG.TechLearning.WPF.CarDiagnostic.ViewModel
{
    public class LiveDataViewModel : ViewModelBaseExt
    {
        private IDataSource _carsDataSource;
        public LiveDataViewModel(IDataSource carsDataSource)
        {
            _carsDataSource = carsDataSource;
            ConnectToDataSourceAsync();
        }

        private double _speedValue = -1;

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

        private async void ConnectToDataSourceAsync()
        {
            if(_carsDataSource == null)
            {
                LogManager.GetCurrentClassLogger().Error($"Could not connect to data source. Data source is null.");
                return;
            }

            if(!_carsDataSource.IsAlive)
            {
                _carsDataSource.OnIsAlive -= OnIsDataSourceAlive;
                _carsDataSource.OnIsAlive += OnIsDataSourceAlive;

                var connectionResult = await _carsDataSource.TryConnectAsync( onErrorCallback: () =>
                {
                    LogManager.GetCurrentClassLogger().Error($"Could not connect to data source: <{_carsDataSource.Name}>. Error occured on data source logic.");
                });

                if(connectionResult)
                {
                    LogManager.GetCurrentClassLogger().Info($"Connected to data source: <{_carsDataSource.Name}> successfully. Waiting for OnIsAlive event.");
                }
                else
                {
                    LogManager.GetCurrentClassLogger().Error($"Could not connect to data source: <{_carsDataSource.Name}>.");
                    //todo: retry in case of DA failure
                }
            }
        }

        private void OnIsDataSourceAlive(object sender, EventArgs e)
        {
            RegisterOnDataSpeedValueChange();
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
