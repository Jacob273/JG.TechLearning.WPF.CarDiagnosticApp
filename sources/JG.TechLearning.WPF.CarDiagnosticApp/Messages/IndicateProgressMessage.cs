using JG.TechLearning.WPF.CarDiagnosticApp.Enums;
using System;

namespace JG.TechLearning.WPF.CarDiagnosticApp.Messages
{
    public class IndicateProgressMessage
    {
        public Action<ProgressResult> OnLoadingEndedCallback;
    }
}
