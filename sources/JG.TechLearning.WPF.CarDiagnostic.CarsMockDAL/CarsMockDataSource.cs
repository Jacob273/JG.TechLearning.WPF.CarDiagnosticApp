using JG.TechLearning.WPF.CarDiagnostic.DataSources.Common;
using JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace JG.TechLearning.WPF.CarDiagnostic.DataSources.CarsMockDataSourceNS
{
    public class CarsMockDataSource : IDataSource
    {
        public CarsMockDataSource()
        {
            GenerateData();
            InitializeTimerForDataSimulation();
        }

        public string Name => Constants.CarsDataSourceName;

        public IEnumerable<Data> Data
        {
            get
            {
                return _dataList;
            }
        }

        private Timer _simulationTimer;
        private bool isTimerRunning;
        private List<Data> _dataList;

        private const string SpeedValueAddress = "SpeedValue";
        private const string TemperatureValueAddress = "TemperatureValue";
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
                _simulationTimer = new Timer(interval: 1500);
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
    }
}
