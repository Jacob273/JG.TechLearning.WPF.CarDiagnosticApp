using JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS;
using System.Collections.Generic;

namespace JG.TechLearning.WPF.CarDiagnostic.IRegistry
{
    public interface IDataSourcesRegistry
    {
        IEnumerable<IDataSource> DataSources { get; }
    }
}
