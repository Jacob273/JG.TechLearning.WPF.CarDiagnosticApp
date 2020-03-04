using JG.TechLearning.WPF.CarDiagnostic.Common;
using JG.TechLearning.WPF.CarDiagnostic.GlobalCommonTypes;
using JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace JG.TechLearning.WPF.CarDiagnostic.DataSources.CarsMockDataSourceNS
{
    public class CarsMockDataSource : IDataSource
    {
        public CarsMockDataSource()
        {
        }

        public string Name => Constants.CarsDataSourceName;

        public IEnumerable<Data> Data
        {
            get
            {
                return _dataList;
            }
        }

        public bool IsAlive { get; private set; }

        private System.Timers.Timer _simulationTimer;
        private bool isTimerRunning;
        private List<Data> _dataList;

        private const string SpeedValueAddress = "SpeedValue";
        private const string TemperatureValueAddress = "TemperatureValue";

        public event EventHandler OnIsAlive;
        public event EventHandler OnIsDead;

        private void GenerateData()
        {
            Data speedValueData = new Data(0.0d, SpeedValueAddress);
            Data temperatureValueData = new Data(0.0d, TemperatureValueAddress);
            _dataList = new List<Data>();
            _dataList.Add(speedValueData);
            _dataList.Add(temperatureValueData);
        }

        private void InitializeTimerForDataSimulation()
        {
            if (!isTimerRunning)
            {
                _simulationTimer = new System.Timers.Timer(interval: 1500);
                _simulationTimer.Elapsed += OnTimedEvent;
                _simulationTimer.AutoReset = true;
                _simulationTimer.Enabled = true;
                isTimerRunning = true;
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var speedValue = _dataList.Find(x => x.Address.Equals(SpeedValueAddress));
            var temperatureValue = _dataList.Find(x => x.Address.Equals(TemperatureValueAddress));
                                  

            Random random = new Random();

            double maximum = 60;
            double minimum = 50;
            speedValue.Value = random.NextDouble() * (maximum - minimum) + minimum;

            maximum = 80;
            minimum = 70;
            temperatureValue.Value = random.NextDouble() * (maximum - minimum) + minimum;
        }

        public async Task<bool> TryConnectAsync(Action onErrorCallback)
        {
            return await Task<bool>.Run(() =>
            {
                try
                {
                        Thread.Sleep(3000);
                        GenerateData();
                        IsAlive = true;
                        OnIsAlive?.Invoke(this, null);
                        InitializeTimerForDataSimulation();
                        return true;
                }
                catch(Exception e)
                {
                    onErrorCallback?.Invoke();
                    return false;
                }
            });
        }
    }
}
