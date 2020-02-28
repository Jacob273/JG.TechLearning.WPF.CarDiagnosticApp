using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JG.TechLearning.WPF.CarDiagnostic.GlobalCommonTypes
{
    public class AssemblyVersionResolver : IVersionResolver
    {
        public string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
