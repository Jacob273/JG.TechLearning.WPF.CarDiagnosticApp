using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS
{
    public interface IDataSource
    {
        string Name { get; }
        IEnumerable<Data> Data { get; }

        bool IsAlive { get; }

        Task<bool> TryConnectAsync(Action onErrorCallback);

        event EventHandler OnIsAlive;

        event EventHandler OnIsDead;
    }
}
