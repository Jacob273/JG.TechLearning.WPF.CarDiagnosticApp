﻿using JG.TechLearning.WPF.CarDiagnostic.DataSources.CarsMockDataSourceNS;
using JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS;
using JG.TechLearning.WPF.CarDiagnostic.IRegistry;
using System.Collections.Generic;

namespace JG.TechLearning.WPF.CarDiagnostic.MockRegistry
{
    public class DataSourceMockRegistry : IDataSourcesRegistry
    {
        public DataSourceMockRegistry()
        {
            CarsMockDataSource carMockDataSource = new CarsMockDataSource();
            _dataSources = new List<IDataSource>();
            _dataSources.Add(carMockDataSource);
        }

        private List<IDataSource> _dataSources;

        public IEnumerable<IDataSource> DataSources => _dataSources;
    }
}
