using JG.TechLearning.WPF.CarDiagnostic.Common.Interfaces;
using System.Reflection;

namespace JG.TechLearning.WPF.CarDiagnostic.Common
{
    public class AssemblyVersionResolver : IVersionResolver
    {
        public string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
