using JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS;
using System.Collections.Generic;

namespace JG.TechLearning.WPF.CarDiagnostic.IDataSourcesPossessorNS
{
    public interface IDataSourcesPossessor
    {
        IEnumerable<IDataSource> DataSources { get; }
    }
}
