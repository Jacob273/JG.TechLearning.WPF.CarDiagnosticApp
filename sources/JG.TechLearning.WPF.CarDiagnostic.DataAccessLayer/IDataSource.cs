using System.Collections.Generic;

namespace JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS
{
    public interface IDataSource
    {
        string Name { get; }
        IEnumerable<Data> Data { get; }
    }
}
